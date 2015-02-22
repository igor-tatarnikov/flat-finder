using System.Linq;
using FlatFinder.Core.Domain;

namespace FlatFinder.Core
{
    public interface IEntityRepository<T> where T : IBaseEntity
    {
        T GetById(int id);
        T GetByPKeys(object[] pkey);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> Table { get; }
    }
}
