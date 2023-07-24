
namespace Library.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IBookRepository BookRepository { get; }
    void SaveChanges();
}
