using Bookstore_System.Application;
using Bookstore_System.Application.Interface;
using Bookstore_System.Domain.Interfaces.Repositories;
using Bookstore_System.Domain.Interfaces.Services;
using Bookstore_System.Domain.Services;
using Bookstore_System.Infrastructure.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace Bookstore_System.IoC
{
    public class DependencyInjector
    {
        private static Container Container { get; set; }

        public static IDependencyResolver Start()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            #region APPLICATION
            Container.Register<ILivroAppService, LivroAppService>();
            Container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            #endregion

            #region SERVICE
            Container.Register<ILivroService, LivroService>();
            Container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            #endregion

            #region REPOSITORY
            Container.Register<ILivroRepository, LivroRepository>();
            Container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            #endregion

            return new SimpleInjectorDependencyResolver(Container);
        }
    }
}
