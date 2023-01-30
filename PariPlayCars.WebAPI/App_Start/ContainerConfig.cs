using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using PariplayCars.Data.Logs.NLog;
using PariPlayCars.Data;
using PariPlayCars.Services.DataServices;
using PariPlayCars.Services.DataServices.Contracts;
using PariPlayCars.Services.DataServices.Decorators;
using PariPlayCars.Services.DataServices.Operators;
using Repositories.GenericRepo;

namespace PariPlayCars.WebAPI.App_Start
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<PariPlayCarsDbContext>().As<DbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<NLogLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<CarRepository>().As<ICarRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CarService>().Named<ICarService>("original").InstancePerLifetimeScope();
            builder.RegisterType<CarServiceExceptionDecorator>().Named<ICarService>("decorator").InstancePerLifetimeScope();
            builder.RegisterType<CarOperator>().As<ICarService>().InstancePerLifetimeScope();
            builder.RegisterType<CarSearcher>().As<CarOperator>().InstancePerLifetimeScope();
            builder.RegisterType<CarGetter>().As<CarOperator>().InstancePerLifetimeScope();
            builder.RegisterType<CarRemover>().As<CarOperator>().InstancePerLifetimeScope();
            builder.RegisterType<CarCreator>().As<CarOperator>().InstancePerLifetimeScope();

            builder.RegisterDecorator<ICarService>((c, inner) => c.ResolveNamed<ICarService>("decorator", TypedParameter.From(inner)), "original").InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}