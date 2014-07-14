using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using FlatFinder.Contracts;

namespace FlatFinder.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        #region Fields

        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        #endregion

        #region Constructor

        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null) 
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        #endregion

        #region IRepository implementation

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual IQueryable<T> GetQuerableAll()
        {
            return DbSet;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        #endregion
    }
}
