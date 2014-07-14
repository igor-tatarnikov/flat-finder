using System.Linq;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Contracts
{
    public interface IFlatAdRepository: IRepository<DetailedFlatAd>
    {
        IQueryable<FlatAd> GetBriefAds();
    }
}
