using Autofac;
using Autofac.Integration.WebApi;
using PariPlayCars.Services.DataServices.Contracts;
using PariPlayCars.WebAPI.App_Start;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PariPlayCars.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = ContainerConfig.Configure();

            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var service = scope.Resolve<ICarService>();
            //}

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
