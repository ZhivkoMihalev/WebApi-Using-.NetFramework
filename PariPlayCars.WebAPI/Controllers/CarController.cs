namespace PariPlayCars.WebAPI.Controllers
{
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.WebAPI.Models.InputModels;
    using PariPlayCars.WebAPI.Models.ViewModels;
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
        public async Task<IEnumerable<CarViewModel>> GetAll()
        {
            var allCars = await this.service.All();
            var result = new List<CarViewModel>();
            foreach (var car in allCars)
            {
                var newCar = new CarViewModel
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year
                };

                result.Add(newCar);
            }

            return result;
        }

        // GET: Car/Details/5
        [HttpGet]
        [Route(nameof(Details))]
        public async Task<CarViewModel> Details(string id)
        {
            var item = await service.GetById(id);

            if (item is null)
            {
                return null;
            }

            var result = new CarViewModel { Brand = item.Brand, Model = item.Brand, Year = item.Year };

            return result;
        }

        // POST: Car/Create
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<CarViewModel> Create(CarInputModel inputCar)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }

                var currentCar = new CarDTO
                {
                    Brand = inputCar.Brand,
                    Model = inputCar.Model,
                    Year = inputCar.Year
                };

                if (this.service.Exist(currentCar))
                {
                    return null;
                }

                await this.service.Create(currentCar);
                var returnCar = new CarViewModel
                {
                    Brand = currentCar.Brand,
                    Model = currentCar.Model,
                    Year = currentCar.Year
                };

                return returnCar;
            }

            catch
            {
                return null;
            }
        }

        // GET: Car/Edit/5
        //[HttpGet]
        //public async Task<CarViewModel> Edit(CarInputModel inputCar)
        //{
        //}

        // POST: Car/Edit/5
        [HttpPost]
        [Route(nameof(Edit))]
        public async Task<CarViewModel> Edit(string id, CarInputModel inputCar)
        {
            try
            {
                var item = await this.service.GetById(id);
                if (item is null)
                {
                    return null;
                }

                if (!ModelState.IsValid)
                {
                    return null;
                }

                item.Brand = inputCar.Brand;
                item.Model = inputCar.Model;
                item.Year = inputCar.Year;

                return new CarViewModel { Brand = item.Brand, Model = item.Model, Year = item.Year };
            }

            catch
            {
                return null;
            }
        }

        // GET: Car/Delete/5
        //[HttpGet]
        //public async Task<CarViewModel> Delete(int id)
        //{
        //    return
        //}

        // POST: Car/Delete/5
        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<CarViewModel> Delete(string id)
        {
            try
            {
                var item = await this.service.GetById(id);
                if (item is null)
                {
                    return null;
                }

                await this.service.Delete(id);
                var returnCar = new CarViewModel
                {
                    Brand = item.Brand,
                    Model = item.Model,
                    Year = item.Year
                };

                return returnCar;
            }

            catch
            {
                return null;
            }
        }
    }
}
