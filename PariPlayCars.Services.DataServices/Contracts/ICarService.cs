namespace PariPlayCars.Services.DataServices.Contracts
{
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> All();

        Task Create(CarDTO car);

        Task<CarDTO> GetById(string id);

        Task Delete(string id);

        Task<IEnumerable<CarDTO>> Search(string search);

        bool Exist(CarDTO car);

    }
}
