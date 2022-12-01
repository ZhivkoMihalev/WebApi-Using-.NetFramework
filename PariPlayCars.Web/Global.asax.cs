using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PariPlayCars.Data;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PariPlayCars.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var db = new PariPlayCarsDbContext();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
