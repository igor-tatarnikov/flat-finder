using System.Web.Http;
using FlatFinder.Contracts;

namespace FlatFinder.Api.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected IFlatFinderUow Uow { get; set; }

        public ApiBaseController(IFlatFinderUow uow)
        {
            Uow = uow;
        }
    }
}
