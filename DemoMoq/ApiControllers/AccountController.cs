using DemoMoq.DataLayer;
using DemoMoq.Models;

namespace DemoMoq.ApiControllers
{
    public class AccountController : BaseApiController
    {
        private readonly IRepository<UserProfileModel> _repository;

        public AccountController(IUnitOfWorkManager unitOfWorkManager, IRepository<UserProfileModel> repository)
            : base(unitOfWorkManager)
        {
            _repository = repository;
        }

        public int Post(UserProfileModel model)
        {
            return (_repository.Insert(model)).Id;
        }
    }
}
