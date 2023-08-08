using Library.DAL.Interfaces;
using Library.DAL.Models;
using System.Linq.Expressions;

namespace Library.DAL.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context) { }
    public async Task<Book> AddBookAsync(Book entity) => await AddAsync(entity);

    public async Task AddRangeBooksAsync(IEnumerable<Book> entities) => await AddRangeAsync(entities);

    public async Task<IEnumerable<Book>> FindBookAsync(Expression<Func<Book, bool>> predicate) => await FindAsync(predicate);

    public async Task<IEnumerable<Book>> GetAllBooksAsync() => await GetAllAsync();

    public async Task<Book?> GetBookAsync(Guid id) => await GetAsync(id);

    public void RemoveBook(Book entity) => Remove(entity);

    public void RemoveRangeBooks(IEnumerable<Book> entities) => RemoveRange(entities);

    public Book UpdateBook(Book entity) => Update(entity);
}
