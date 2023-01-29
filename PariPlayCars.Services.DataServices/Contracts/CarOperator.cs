namespace PariPlayCars.Services.DataServices.Contracts
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using PariPlayCars.Services.DataServices.Models;

    public abstract class CarOperator : ICarService
    {
        private readonly ICarService _service;

        public CarOperator(ICarService service)
        {
            this._service = service;
        }

        public virtual async Task CreateAsync(CarDTO car)
        {
            await this._service.CreateAsync(car);
        }

        public virtual async Task DeleteAsync(CarDTO car)
        {
            await this._service.DeleteAsync(car);
        }

        public virtual async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            return await this._service.GetAllAsync();
        }

        public virtual async Task<CarDTO> GetByIdAsync(string id)
        {
            return await this._service.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            return await this._service.SearchByBrandAsync(search);
        }

        public virtual async Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            return await this._service.SearchByModelAsync(search);
        }

        public virtual async Task Update(string id, CarDTO newCar)
        {
            await this._service.Update(id, newCar);
        }
    }
}
