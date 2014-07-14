using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Api.Controllers
{
    public class LookupController : ApiBaseController
    {
        #region Constructor

        public LookupController(IFlatFinderUow uow)
            : base(uow)
        {
        }

        #endregion

        #region Actions

        // GET: api/lookups/districts
        [ActionName("districts")]
        public IEnumerable<District> GetDistricts()
        {
            return Uow.Districts
                      .GetQuerableAll()
                      .OrderBy(r => r.Name);
        }

        #endregion
    }
}
