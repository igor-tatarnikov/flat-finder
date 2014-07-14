using System;
using System.Collections.Generic;
using System.Data.Entity;
using FlatFinder.Contracts;

namespace FlatFinder.Data.Infrastructure
{
    public class RepositoryFactories
    {
        #region Fields

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        #endregion

        #region Constructor
        public RepositoryFactories()
        {
            _repositoryFactories = GetFlatFinderFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        } 
        #endregion

        #region Public methods

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EfRepository<T>(dbContext);
        }

        #endregion

        #region Private methods

        private IDictionary<Type, Func<DbContext, object>> GetFlatFinderFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
                {typeof(IFlatAdRepository), dbContext => new FlatAdRepository(dbContext)},
            };
        }

        #endregion
    }
}
