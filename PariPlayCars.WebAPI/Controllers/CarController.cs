namespace PariPlayCars.WebAPI.Controllers
{
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.WebAPI.Models.InputModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    [Route("api/[controller]")]
    public class CarController : ApiController
    {
        private readonly ICarService service;

        public CarController(ICarService carService)
        {
            this.service = carService;
        }

        // GET: Car
        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IEnumerable<CarDTO>> GetAll()
        {
            return await this.service.GetAllAsync();
        }

        // GET: Car/Details/5
        [HttpGet]
        [Route(nameof(Details))]
        public async Task<CarDTO> Details(string id)
        {
            return await service.GetByIdAsync(id);
        }

        // POST: Car/Create
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<CarDTO> Create(CarInputModel inputCar)
        {
            var currentCar = new CarDTO
            {
                Brand = inputCar.Brand,
                Model = inputCar.Model,
                Year = inputCar.Year
            };

            await this.service.CreateAsync(currentCar);
            return currentCar;
        }

        // GET: Car/Edit/5
        //[HttpGet]
        //public async Task<CarDTO> Edit(CarInputModel inputCar)
        //{
        //}

        // POST: Car/Edit/5
        [HttpPost]
        [Route(nameof(Edit))]
        public async Task Edit(string id, CarDTO inputCar)
        {
            if (!ModelState.IsValid)
            {
                //return message "It doesn't exist a car with this id.
            }

            await this.service.Update(id, inputCar);
        }

        // GET: Car/Delete/5
        //[HttpGet]
        //public async Task<CarDTO> Delete(int id)
        //{
        //    return
        //}

        // POST: Car/Delete/5
        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<CarDTO> Delete(string id)
        {
            return await this.Delete(id);
        }
    }
}
