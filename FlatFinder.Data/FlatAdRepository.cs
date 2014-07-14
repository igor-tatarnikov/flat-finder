using System.Data.Entity;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;
using System.Linq;

namespace FlatFinder.Data
{
    public class FlatAdRepository: EfRepository<DetailedFlatAd>, IFlatAdRepository
    {
        #region Constructor

        public FlatAdRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        #endregion

        #region IFlatAdRepository implementation

        public IQueryable<FlatAd> GetBriefAds()
        {
            return DbSet.Select(t => new FlatAd
                {
                    ContactInfo = t.ContactInfo,
                    ContactInfoId = t.ContactInfoId,
                    FlatInfo = t.FlatInfo,
                    Id = t.Id,
                    FlatInfoId = t.FlatInfoId,
                    Price = t.Price
                });
        }

        #endregion
    }
}
