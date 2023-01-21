namespace PariPlayCars.Services.DataServices.Decorators
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;

    public class CarServiceExceptionDecorator : ICarServiceDecorator
    {
        private readonly ICarService _decorated;
        private readonly ILogger _logger;

        public CarServiceExceptionDecorator(ICarService decorated, ILogger logger)
        {
            this._decorated = decorated;
            this._logger = logger;
        }

        public async Task CreateAsync(CarDTO car)
        {
            try
            {
                await this._decorated.CreateAsync(car);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }

        public async Task DeleteAsync(CarDTO car)
        {
            try
            {
                await this._decorated.DeleteAsync(car);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            try
            {
                return await this._decorated.GetAllAsync();
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                throw;
            }
        }

        public async Task<CarDTO> GetByIdAsync(string id)
        {
            try
            {
                return await this._decorated.GetByIdAsync(id);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                throw;
            }
        }

        public async Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            try
            {
                return await this._decorated.SearchByBrandAsync(search);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                throw;
            }
        }

        public async Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            try
            {
                return await this._decorated.SearchByModelAsync(search);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                throw;
            }
        }

        public async Task Update(string id, CarDTO newCar)
        {
            try
            {
                await this._decorated.Update(id, newCar);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }
    }
}
