using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace nks.core.DataAccess;

public class EfEntityRepositoryAsyncBase<TEntity, TContext> : EfEntityRepositoryBase<TEntity, TContext>, IEntityRepositoryAsync<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
{
    public async Task AddAsync(TEntity entity)
    {
        using (var context=new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }
    }
    public async Task<int> DeleteAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return await context.SaveChangesAsync();
        }
    }
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        using (var context = new TContext())
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
    {
        using (var context = new TContext())
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
