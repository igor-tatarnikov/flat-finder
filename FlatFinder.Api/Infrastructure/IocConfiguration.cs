using System.Web.Http;
using FlatFinder.Contracts;
using FlatFinder.Data;
using FlatFinder.Data.Infrastructure;
using Ninject;

namespace FlatFinder.Api.Infrastructure
{
    public class IocConfiguration
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IFlatFinderUow>().To<FlatFinderUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}