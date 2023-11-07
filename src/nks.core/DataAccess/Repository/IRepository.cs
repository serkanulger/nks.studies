using System.Linq.Expressions;
using nks.core.DataAccess;

namespace nks.core.DataAccess;

public interface IRepository<TEntity, TKey> : IDisposable, IAsyncDisposable where TEntity : class where TKey : class
{
    Task<TEntity?> GetAsync(TKey id);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TKey id);
}
