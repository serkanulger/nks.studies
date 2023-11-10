namespace nks.core.DataAccess;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    //Start the database Transaction
    Task CreateTransactionAsync();

    //Commit the database Transaction
    Task CommitAsync();

    //Rollback the database Transaction
    Task RollbackAsync();

    //DbContext Class SaveChanges method
    Task<int> SaveAsync();

    IRepository<T, Key> Repository<T, Key>() where T : class where Key : class;
}
