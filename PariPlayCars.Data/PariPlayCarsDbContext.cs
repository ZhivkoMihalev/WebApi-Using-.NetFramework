namespace PariPlayCars.Data
{
    using PariPlayCars.Data.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public class PariPlayCarsDbContext : DbContext
    {
        public PariPlayCarsDbContext()
        {

        }

        public PariPlayCarsDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<PariPlayCarsDbContext>(new CreateDatabaseIfNotExists<PariPlayCarsDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PariPlayCarsDbContext, Data.Migrations.Configuration>());
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
