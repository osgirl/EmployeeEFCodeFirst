using System.Web.Mvc;
using System.Web.Routing;
using CodeFirstData.DBInteractions;
using CodeFirstData.EntityRepositories;
using CodeFirstPortal.IoC;
using CodeFirstServices.Interfaces;
using CodeFirstServices.Services;
using Microsoft.Practices.Unity;

namespace MvcPortal
{
   
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            IUnityContainer container = GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            
        }

        private IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            IUnityContainer container = new UnityContainer()
            .RegisterType<IDBFactory, DBFactory>(new HttpContextLifetimeManager<IDBFactory>())
            .RegisterType<IUnitOfWork, UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>())
            .RegisterType<IEmployeeService, EmployeeService>(new HttpContextLifetimeManager<IEmployeeService>())
            .RegisterType<IEmployeeRepository, EmployeeRepository>(new HttpContextLifetimeManager<IEmployeeRepository>());
            return container;
        }
    }
}