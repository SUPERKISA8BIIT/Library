
using Library.DAL.Interfaces;

namespace Library.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context = null!;
    private BookRepository _bookRepository = null!;
    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }
    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);
    public void SaveChanges() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();


}
