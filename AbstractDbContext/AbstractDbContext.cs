namespace AbstractDbContext
{
    using PariPlayCars.Data;
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System;
    using System.Threading.Tasks;

    //If we have more repositories, we have to initialize them here like _carRepo
    public class AbstractDbContext : IAbstractDbContext
    {
        private PariPlayCarsDbContext _context;
        private IGenericRepository<Car> _carRepo;

        public AbstractDbContext(PariPlayCarsDbContext context)
        {
            this._context = context;
        }

        public IGenericRepository<Car> CarRepo
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

        public IGenericRepository<Car> CarRepository => throw new NotImplementedException();

        public async Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
