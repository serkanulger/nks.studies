
namespace nks.core.DataAccess;

public class UnitOfWork<TContext> : IUnitOfWork
{
    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void CreateTransaction()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public IRepository<TEntity, TKey> Repository<TEntity, TKey>()
        where TEntity : class
        where TKey : class
    {
        throw new NotImplementedException();
    }

    public void Rollback()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }
}
