namespace UnifOfWorkDbContext
{
    using PariPlayCars.Data;
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System;
    using System.Threading.Tasks;

    //If we have more repositories, we have to initialize them here like _carRepo
    public class UnifOfWorkDbContext : IUnifOfWorkDbContext
    {
        private PariPlayCarsDbContext _context;
        private IGenericRepository<Car> _carRepo;

        public UnifOfWorkDbContext(PariPlayCarsDbContext context)
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
