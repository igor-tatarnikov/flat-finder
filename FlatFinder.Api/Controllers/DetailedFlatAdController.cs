using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Api.Controllers
{
    public class DetailedFlatAdController : ApiBaseController
    {
        #region Constructor

        public DetailedFlatAdController(IFlatFinderUow uow)
            : base(uow)
        {
        }

        #endregion

        #region Actions

        // GET /api/detailedflatad
        public IEnumerable<DetailedFlatAd> Get()
        {
            return Uow.FlatAdRepository.GetQuerableAll();
        }

        // GET /api/detailedflatad/5
        public DetailedFlatAd Get(int id)
        {
            var person = Uow.FlatAdRepository.GetById(id);
            if (person != null) return person;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        // Add a new ad
        // POST /api/detailedflatad/
        public HttpResponseMessage Post(DetailedFlatAd ad)
        {
            Uow.FlatAdRepository.Insert(ad);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // Update an existing ad
        // PUT /api/detailedflatad/
        public HttpResponseMessage Put(DetailedFlatAd ad)
        {
            Uow.FlatAdRepository.Update(ad);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        #endregion
    }
}
