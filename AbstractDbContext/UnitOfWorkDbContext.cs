namespace UnitOfWorkDbContext
{
    using PariPlayCars.Data;
    using System.Threading.Tasks;
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;

    //If we have more repositories, we have to initialize them here like _carRepo
    public class UnitOfWorkDbContext : IUnitOfWorkDbContext
    {
        private PariPlayCarsDbContext _context;
        private IGenericRepository<Car> _carRepo;

        public UnitOfWorkDbContext(PariPlayCarsDbContext context)
        {
            this._context = context;
        }

        public IGenericRepository<Car> CarRepository
        {
            get
            {
                if (_carRepo == null)
                {
                    this._carRepo = new CarRepository(_context);
                }

                return this._carRepo;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
