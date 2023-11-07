using System.Linq.Expressions;

namespace nks.core.DataAccess;

public interface IEntityRepository<T> where T:class,IEntity,new()
{
    T? Get(Expression<Func<T, bool>> filter);
    IList<T> GetList(Expression<Func<T, bool>>? filter = null );
    void Add(T entity);
    int Update(T entity);
    int Delete(T entity);
}

public interface IEntityRepositoryAsync<T> where T:class,IEntity,new()
{
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? filter = null );
    Task AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
}
