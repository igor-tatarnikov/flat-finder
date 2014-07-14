using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace FlatFinder.Data
{
    public class FlatFinderDbContext: DbContext, IDbContext
    {
        #region Constructor

        public FlatFinderDbContext()
            : base(nameOrConnectionString: "FlatFinder")
        {
        }

        public FlatFinderDbContext(string connectionStringOrName)
            : base(connectionStringOrName)
        {
        }

        #endregion

        #region Protected Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }


            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region IDbContext Interface Implementation

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion
    }
}
