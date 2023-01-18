using PariPlayCars.Data.Middlewares.Contracts;
using PariPlayCars.Services.DataServices.Contracts;
using PariPlayCars.Services.DataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayCars.Services.DataServices.Decorators
{
    public class CarServiceExceptionDecorator : ICarService
    {
        private readonly ICarService _decorated;
        private readonly IExceptionMiddleware _middleware;

        public CarServiceExceptionDecorator(ICarService decorated, IExceptionMiddleware middleware)
        {
            _decorated = decorated;
            this._middleware = middleware;
        }

        public Task CreateAsync(CarDTO car)
        {
            this._middleware.InvokeAsync();
            return _decorated.CreateAsync(car);
        }

        public Task DeleteAsync(CarDTO car)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CarDTO> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task Update(string id, CarDTO newCar)
        {
            throw new NotImplementedException();
        }
    }
}
