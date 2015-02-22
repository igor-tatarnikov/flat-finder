using System.Data.Entity;

namespace FlatFinder.Data
{
    public interface IBaseDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
