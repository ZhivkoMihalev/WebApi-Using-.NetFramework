using PariPlayCars.Data.Common;
using PariPlayCars.Services.DataServices;
using PariPlayCars.Services.DataServices.Contracts;
using PizzaLab.Data;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PariPlayCars.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICarService, CarService>();
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}