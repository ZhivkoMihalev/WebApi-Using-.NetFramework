namespace PariPlayCars.Services.DataServices.Contracts
{
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> GetAllAsync();

        Task CreateAsync(CarDTO car);

        Task<CarDTO> GetByIdAsync(string id);

        Task Delete(string id);

        Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search);

        Task<IEnumerable<CarDTO>> SearchByModelAsync(string search);

        Task Update(string id, CarDTO newCar);
    }
}
