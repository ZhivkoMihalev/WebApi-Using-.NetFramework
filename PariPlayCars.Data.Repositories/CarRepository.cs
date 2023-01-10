namespace PariPlayCars.Data
{
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        //public CarRepository(IAbstractDbContext<PariPlayCarsDbContext> abstractContext)
        //    : base(abstractContext)
        //{
        //}

        public CarRepository(PariPlayCarsDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Car>> SearchByBrand(string search)
        {
            //return await this.Entities.Where(x => x.Brand == search).ToListAsync();

            return await this.Context.Cars.Where(x => x.Brand == search).ToListAsync();
        }

        public async Task<IEnumerable<Car>> SearchByModel(string search)
        {
            //return await this.Entities.Where(x => x.Model == search).ToListAsync();

            return await this.Context.Cars.Where(x => x.Model == search).ToListAsync();
        }
    }
}
