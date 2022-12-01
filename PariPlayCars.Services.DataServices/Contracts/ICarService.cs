namespace PariPlayCars.Services.DataServices.Contracts
{
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;

    public interface ICarService
    {
        IEnumerable<CarDTO> All();

        void Create(CarDTO car);

        CarDTO GetById(string id);

        void Delete(CarDTO car);

        IEnumerable<CarDTO> Search(string search);

        bool Exist(CarDTO car);

    }
}
