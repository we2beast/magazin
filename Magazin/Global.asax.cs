using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Magazin.Infrastructure;
using Ninject.Web.Mvc;
using AutoMapper;
using Magazin.App_Start;

namespace Magazin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; private set; }
        protected void Application_Start()
        {
            MapperConfiguration = MapperConfig.GetConfiguration();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
