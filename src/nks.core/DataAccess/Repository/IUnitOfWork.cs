namespace nks.core.DataAccess;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    //Start the database Transaction
    void CreateTransaction();

    //Commit the database Transaction
    void Commit();

    //Rollback the database Transaction
    void Rollback();

    //DbContext Class SaveChanges method
    void Save();

    IRepository<T, Key> Repository<T, Key>() where T : class where Key : class;
}
