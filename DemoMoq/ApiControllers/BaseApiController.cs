using System.Web.Http;
using DemoMoq.DataLayer;

namespace DemoMoq.ApiControllers
{
    public class BaseApiController : ApiController
    {
        protected readonly IUnitOfWorkManager UnitOfWorkManager;

        public BaseApiController(IUnitOfWorkManager unitOfWorkManager)
        {
            UnitOfWorkManager = unitOfWorkManager;
        }
    }
}
