
using System.Linq.Expressions;

namespace Library.DAL.Interfaces;

public interface IBaseRepository<TEntity>
{
    Task<TEntity?> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);
}
