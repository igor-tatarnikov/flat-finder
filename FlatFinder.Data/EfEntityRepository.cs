using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using FlatFinder.Core;
using FlatFinder.Core.Domain;

namespace FlatFinder.Data
{
    public class EfEntityRepository<T> : EfRepository, IEntityRepository<T> where T : BaseEntityAuditDate
    {
        private IDbSet<T> _entities;

        #region Ctor

        public EfEntityRepository(IDbContext context)
            : base(context)
        {
        }

        #endregion

        private IDbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }


        #region IRepository Inteface Implementation

        public T GetById(int id)
        {
            return Entities.Find(id);
        }

        public T GetByPKeys(object[] pkeys)
        {
            return Entities.Find(pkeys);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg +=
                            string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                                          validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context.Set<T>().Remove(entity);
                Context.SaveChanges();

                //TODO:  We need to add a soft delete field to the tables to make sure there is no hard deletes.
                //End Date, etc
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                throw fail;
            }
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        #endregion
    }
}
