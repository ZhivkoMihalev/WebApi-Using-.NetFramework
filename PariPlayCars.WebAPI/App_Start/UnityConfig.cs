namespace PariPlayCars.WebAPI
{
    using Nest;
    using PariPlayCars.Services.DataServices;
    using PariPlayCars.Services.DataServices.Contracts;
    using System.Web.Http;
    using Unity;
    using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICarService, CarService>();
            container.RegisterType(typeof(IRepository<>), typeof(IRepository<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}