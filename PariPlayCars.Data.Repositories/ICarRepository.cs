namespace PariPlayCars.Data
{
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> SearchByBrand(string brand);

        Task<IEnumerable<Car>> SearchByModel(string model);
    }
}