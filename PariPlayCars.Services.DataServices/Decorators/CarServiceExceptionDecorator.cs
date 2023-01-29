namespace PariPlayCars.Services.DataServices.Decorators
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Operators;

    public class CarServiceExceptionDecorator : ICarService
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
            var creator = new CarCreator(this._decorated, this._logger);
            await creator.CreateAsync(car);
        }

        public async Task DeleteAsync(CarDTO car)
        {
            var remover = new CarRemover(this._decorated, this._logger);
            await remover.DeleteAsync(car);
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            var getter = new CarGetter(this._decorated, this._logger);
            return await getter.GetAllAsync();
        }

        public async Task<CarDTO> GetByIdAsync(string id)
        {
            var getter = new CarGetter(this._decorated, this._logger);
            return await getter.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            var searcher = new CarSearcher(this._decorated, this._logger);
            return await searcher.SearchByBrandAsync(search);
        }

        public async Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            var searcher = new CarSearcher(this._decorated, this._logger);
            return await searcher.SearchByModelAsync(search);
        }

        public async Task Update(string id, CarDTO newCar)
        {
            var editor = new CarEditor(this._decorated, this._logger);
            await editor.Update(id, newCar);
        }
    }
}
