namespace PariPlayCars.WebAPI
{
    using Autofac;
    using Autofac.Integration.WebApi;
    using Repositories.GenericRepo;
    using System.Web.Http;

    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Data;
    using PariPlayCars.Services.DataServices;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Decorators;
    using UnitOfWorkDbContext;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CarService>().Named<ICarService>("original");
            builder.RegisterType<CarServiceExceptionDecorator>().Named<ICarService>("decorator");
            builder.RegisterDecorator<ICarService>((c, inner) => c.ResolveNamed<ICarService>("decorator", TypedParameter.From(inner)), "implementation");
            //RegisterDecorator<ICarService, CarService, CarServiceExceptionDecorator>(builder);

            builder.RegisterType<CarRepository>().Named<ICarRepository>("repository");
            builder.RegisterType<UnitOfWorkDbContext>().Named<IUnitOfWorkDbContext>("unitOfWork");
            builder.RegisterType<NLogLogger>().Named<ILogger>("NLogger");
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

            var container = builder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }

        //private static void RegisterDecorator<TInterface, TImplementation, TDecorator>(ContainerBuilder builder)
        //    where TImplementation : TInterface 
        //    where TDecorator : TInterface
        //{
        //    builder.RegisterType<TImplementation>().Named<TInterface>("implementation");
        //    builder.RegisterType<TDecorator>().Named<TInterface>("decorator");
        //    builder.RegisterDecorator<TInterface>((c, inner) => c.ResolveNamed<TInterface>("decorator", TypedParameter.From(inner)), "implementation");
        //}
    }
}