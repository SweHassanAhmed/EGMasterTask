using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Data.Infrastructure;
using System.Data.Entity;
using Data;
using Data.Repository;
using Service.Contract;
using Service.Services;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);
            container.Register<IDBFactory, DBFactory>(Lifestyle.Singleton);
            container.Register<DbContext, BaseEntity>(Lifestyle.Singleton);

            container.Register<IClientRepo, ClientRepo>(Lifestyle.Singleton);
            container.Register<ICallRepo, CallRepo>(Lifestyle.Singleton);
            container.Register<IEmployeeRepo, EmployeeRepo>(Lifestyle.Singleton);

            container.Register<ICallService, CallService>(Lifestyle.Singleton);
            container.Register<IClientService, ClientService>(Lifestyle.Singleton);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
    }
}
