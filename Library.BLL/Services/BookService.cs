
using AutoMapper;
using Library.BLL.DTOs.AddDto;
using Library.BLL.DTOs.GetDto;
using Library.BLL.DTOs.UpdateDto;
using Library.BLL.Exceptions;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using System.Threading.Tasks;

namespace Library.BLL.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> AddBookAsync(AddBookDto book)
    {
        var result = _mapper.Map<Book>(book);

        var searchedByISBN = await _unitOfWork.BookRepository.FindBookAsync(x => x.ISBN == result.ISBN);
        if (!searchedByISBN.Any()) throw new ConflictException($"book with this ISBN: {result.ISBN} already exists");

        await _unitOfWork.BookRepository.AddBookAsync(result);
        _unitOfWork.SaveChanges();
        return result.Id;
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var book = await _unitOfWork.BookRepository.GetBookAsync(id);

        if (book == null) throw new NotFoundException($"there is no book with this Id: {id}");

        _unitOfWork.BookRepository.RemoveBook(book);
        _unitOfWork.SaveChanges();
    }

    public async Task<GetBookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _unitOfWork.BookRepository.GetBookAsync(id);

        if (book == null) throw new NotFoundException($"there is no book with this Id: {id}");

        return _mapper.Map<GetBookDto>(book);
    }

    public async Task<GetBookDto> GetBookByISBN(string ISBN)
    {
        var book = await _unitOfWork.BookRepository.FindBookAsync(x => x.ISBN == ISBN);

        if (!book.Any()) throw new NotFoundException("there is no book with this ISBN");
        
        return _mapper.Map<GetBookDto>(book.First());
    }

    public async Task<IEnumerable<GetBookDto>> GetBooksAsync()
    {
        var books = await _unitOfWork.BookRepository.GetAllBooksAsync();

        return _mapper.Map<IEnumerable<GetBookDto>>(books);
    }

    public async Task<GetBookDto> UpdateBookAsync(UpdateBookDto book, Guid id)
    {
    
        var boook = await _unitOfWork.BookRepository.GetBookAsync(id);
        if (boook == null) throw new NotFoundException("there is no book with this Id");
        var mappedItem = _mapper.Map(book, boook);
        _unitOfWork.BookRepository.UpdateBook(mappedItem);
        _unitOfWork.SaveChanges();

        return _mapper.Map<GetBookDto>(boook);
    }
}
