using System.Web.Http;
using DemoMoq.Library;
using DemoMoq.Models;
using Microsoft.Practices.Unity;


namespace DemoMoq.DataLayer
{
    public class UnityBuilder
    {
        public static void Start()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.BindInRequestScope<IDataContext, DataContext>();
            container.BindInRequestScope<IUnitOfWorkManager, UnitOfWorkManager>();
            container.BindInRequestScope<IRepository<UserProfileModel>, Repository<UserProfileModel>>();

            return container;
        }
    }
}
