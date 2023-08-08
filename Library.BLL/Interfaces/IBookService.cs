using Library.BLL.DTOs.AddDto;
using Library.BLL.DTOs.GetDto;
using Library.BLL.DTOs.UpdateDto;

namespace Library.BLL.Interfaces;

public interface IBookService
{
    Task<IEnumerable<GetBookDto>> GetBooksAsync();
    Task<GetBookDto> GetBookByIdAsync(Guid id);
    Task<GetBookDto> GetBookByISBN(string ISBN);
    Task<Guid> AddBookAsync(AddBookDto book);
    Task<GetBookDto> UpdateBookAsync(UpdateBookDto book, Guid id);
    Task DeleteBookAsync(Guid id);
}
