using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using FlatFinder.Core.Domain;

namespace FlatFinder.Data
{
    public class FlatFinderBaseDbContext : DbContext, IBaseDbContext
    {
        #region Ctor

        public FlatFinderBaseDbContext()
        {
            const int commandTimeout = 300;
            this.Database.CommandTimeout = commandTimeout;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = commandTimeout;
        }

        public FlatFinderBaseDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            const int commandTimeout = 300;
            this.Database.CommandTimeout = commandTimeout;
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = commandTimeout;
        }

        #endregion

        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                          .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                          .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                                                         &&
                                                         type.BaseType.GetGenericTypeDefinition() ==
                                                         typeof (EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }


            base.OnModelCreating(modelBuilder);
        }

        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity)
            where TEntity : BaseEntityAuditDate, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }
            else
            {
                //entity is already loaded.
                return alreadyAttached;
            }
        }

        #endregion

        #region IBaseDbContext interface Implementation

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
