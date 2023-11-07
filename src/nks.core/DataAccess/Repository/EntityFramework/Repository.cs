using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace nks.core.DataAccess;

public class Repository<T, Key> : IRepository<T, Key> where T : class where Key : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        if (_dbContext.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(Key id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }

    public async Task<IQueryable<T>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _dbSet;
    }

    public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        await Task.CompletedTask;
        return _dbSet.Where(predicate);
    }

    public async Task<T?> GetAsync(Key id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        Dispose();
        await Task.CompletedTask;
    }
}
