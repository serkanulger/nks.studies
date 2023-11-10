
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace nks.core.DataAccess;

public class UnitOfWork: IUnitOfWork
{
    private readonly DbContext _dbContext;
    private bool _disposed;
    private string _errorMessage = string.Empty;
    //The following Object is going to hold the Transaction Object
    private IDbContextTransaction? _objTran;

    public UnitOfWork(DbContext dbContext)
    {
        _dbContext = dbContext;
        _objTran = null;
    }

    public IRepository<TEntity, TKey> Repository<TEntity, TKey>()
        where TEntity : class
        where TKey : class
    {
        return new Repository<TEntity, TKey>(_dbContext);
    }

    public async Task CommitAsync()
    {
        if (_objTran != null)
        {
            //Commits the underlying store transaction
            await _objTran.CommitAsync();
        }
    }

    public async Task CreateTransactionAsync()
    {
        // It will Begin the transaction on the underlying store connection
        _objTran = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task RollbackAsync()
    {
        if (_objTran != null)
        {
            //Rolls back the underlying store transaction
            await _objTran.RollbackAsync();
            //The Dispose Method will clean up this transaction object and ensures Entity Framework
            //is no longer using that transaction.
            await _objTran.DisposeAsync();
        }
    }

    public async Task<int> SaveAsync()
    {
        try
        {
            //Calling DbContext Class SaveChanges method 
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
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
