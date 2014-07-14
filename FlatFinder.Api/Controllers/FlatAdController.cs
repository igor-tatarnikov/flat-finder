using System.Collections.Generic;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Api.Controllers
{
    public class FlatAdController : ApiBaseController
    {
        #region Constructor

        public FlatAdController(IFlatFinderUow uow)
            : base (uow)
        {
        }

        #endregion

        #region Actions

        //GET api/flatAd
        public IEnumerable<FlatAd> Get()
        {
            return Uow.FlatAdRepository.GetBriefAds();
        }

        #endregion
    }
}
