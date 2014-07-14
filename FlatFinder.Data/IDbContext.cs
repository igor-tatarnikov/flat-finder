using System.Data.Entity;

namespace FlatFinder.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
