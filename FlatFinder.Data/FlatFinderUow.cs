using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Configuration;
using FlatFinder.Core.Domain.Ad;
using FlatFinder.Core.Domain.User;
using FlatFinder.Data.Infrastructure;

namespace FlatFinder.Data
{
    public class FlatFinderUow : IFlatFinderUow, IDisposable
    {
        #region Constructor

        public FlatFinderUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        #endregion


        #region IFlatFinderUow implementation

        public IRepository<FlatInfo> FlatInfos
        {
            get { return GetStandardRepo<FlatInfo>(); }
        }

        public IRepository<ContactInfo> ContactInfos
        {
            get { return GetStandardRepo<ContactInfo>(); }
        }

        public IRepository<District> Districts
        {
            get { return GetStandardRepo<District>(); }
        }

        public IRepository<Address> Addresses
        {
            get { return GetStandardRepo<Address>(); }
        }

        public IFlatAdRepository FlatAdRepository
        {
            get { return GetRepo<IFlatAdRepository>(); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion

        #region Private methods

        protected void CreateDbContext()
        {
            DbContext = new FlatFinderDbContext(Config.DatabaseConnectionString);

            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private FlatFinderDbContext DbContext { get; set; }

        #endregion
    }
}
