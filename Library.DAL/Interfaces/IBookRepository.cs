
using Library.DAL.Models;
using System.Linq.Expressions;

namespace Library.DAL.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetBookAsync(Guid id);
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<IEnumerable<Book>> FindBookAsync(Expression<Func<Book, bool>> predicate);
    Task<Book> AddBookAsync(Book entity);
    Task AddRangeBooksAsync(IEnumerable<Book> entities);
    void RemoveBook(Book entity);
    void RemoveRangeBooks(IEnumerable<Book> entities);
    Book UpdateBook(Book entity);
}
