namespace FlatFinder.Data
{
    public abstract class EfRepository
    {
        protected readonly IDbContext Context;

        #region Ctor

        protected EfRepository(IDbContext context)
        {
            Context = context;
        }

        #endregion
    }
}
