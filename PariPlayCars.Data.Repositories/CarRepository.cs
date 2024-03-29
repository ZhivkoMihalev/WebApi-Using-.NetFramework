﻿namespace PariPlayCars.Data
{
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Collections.Generic;

    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(PariPlayCarsDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Car>> SearchByBrand(string search)
        {
            return await this.Context.Cars.Where(x => x.Brand == search).ToListAsync();
        }

        public async Task<IEnumerable<Car>> SearchByModel(string search)
        {
            return await this.Context.Cars.Where(x => x.Model == search).ToListAsync();
        }
    }
}
