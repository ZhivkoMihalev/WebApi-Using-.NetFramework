namespace PariPlayCars.WebAPI.Controllers
{
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class CarController : ApiController
    {
        private readonly ICarService _service;

        public CarController(ICarService carService)
        {
            this._service = carService;
        }

        // GET: Car
        [HttpGet]
        public async Task<IEnumerable<CarDTO>> GetAll()
        {
            return await this._service.GetAllAsync();
        }

        // GET: Car/Details/5
        [HttpGet]
        public async Task<CarDTO> Details(string id)
        {
            return await this._service.GetByIdAsync(id);
        }

        // POST: Car/Create
        [HttpPost]
        public async Task Create(CarDTO inputCar)
        {
            await this._service.CreateAsync(inputCar);
        }

        // POST: Car/Edit/5
        [HttpPost]
        public async Task Edit(string id, CarDTO inputCar)
        {
            await this._service.Update(id, inputCar);
        }

        // POST: Car/Delete/5
        [HttpDelete]
        public async Task Delete(CarDTO deleteCar)
        {
            await this._service.DeleteAsync(deleteCar);
        }
    }
}
