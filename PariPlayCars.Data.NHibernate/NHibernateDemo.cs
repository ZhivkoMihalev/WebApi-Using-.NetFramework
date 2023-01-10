using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using PariPlayCars.Data.Models;
using System.Reflection;

namespace PariPlayCars.Data.NHibernate
{
    public class NHibernateDemo
    {
        private static void Main()
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=ZHIVKOM20;Database=PariPlayCars;User Id=ZhivkoMihalev;Password=QQQqqq!!!111";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sessionFactory = cfg.BuildSessionFactory();
            using (var session = sessionFactory.OpenSession())
            using (var tx = session.BeginTransaction())
            {
                //perform database logic
                var cars = session.CreateCriteria<Car>().List<Car>();

                tx.CommitAsync();
            }
        }
    }
}
