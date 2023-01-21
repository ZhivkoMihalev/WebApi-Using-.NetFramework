namespace PariPlayCars.WebAPI
{
    using Nest;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Data;
    using PariPlayCars.Services.DataServices;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Decorators;
    using Repositories.GenericRepo;
    using System.Web.Http;
    using UnitOfWorkDbContext;
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
            container.RegisterType<ICarServiceDecorator, CarServiceExceptionDecorator>();
            container.RegisterType(typeof(IGenericProperty));
            container.RegisterType<ICarRepository, CarRepository>();
            container.RegisterType<IUnitOfWorkDbContext, UnitOfWorkDbContext>();
            container.RegisterType<ILogger, NLogLogger>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}