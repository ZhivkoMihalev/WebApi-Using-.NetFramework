namespace PariPlayCars.WebAPI.Controllers
{
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.WebAPI.Models.InputModels;
    using PariPlayCars.WebAPI.Models.ViewModels;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService service;

        public CarController(ICarService carService)
        {
            this.service = carService;
        }

        // GET: Car
        [HttpGet]
        [Route(nameof(GetAll))]
        public IEnumerable<CarViewModel> GetAll()
        {
            var allCars = new List<CarViewModel>();
            foreach (var car in this.service.All())
            {
                var newCar = new CarViewModel
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year
                };

                allCars.Add(newCar);
            }

            return allCars;
        }

        // GET: Car/Details/5
        [HttpGet]
        [Route(nameof(Details))]
        public CarViewModel Details(string id)
        {
            var item = service.GetById(id);

            if (item is null)
            {
                return null;
            }

            var result = new CarViewModel { Brand = item.Brand, Model = item.Model, Year = item.Year };

            return result;
        }

        // GET: Car/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [Route(nameof(Create))]
        public ActionResult Create(CarInputModel inputCar)
        {
            try
            {
                var currentCar = new CarDTO
                {
                    Brand = inputCar.Brand,
                    Model = inputCar.Model,
                    Year = inputCar.Year
                };

                if (this.service.Exist(currentCar))
                {
                    return View();
                }

                this.service.Create(currentCar);
                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        [HttpGet]
        public ActionResult Edit(CarInputModel inputCar)
        {
            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        [Route(nameof(Edit))]
        public CarViewModel Edit(string id, CarInputModel inputCar)
        {
            try
            {
                var item = this.service.GetById(id);
                if (item is null)
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpDelete]
        [Route(nameof(Delete))]
        public ActionResult Delete(string id, CarInputModel inputCar)
        {
            try
            {
                var item = this.service.GetById(id);
                if (item is null)
                {
                    return HttpNotFound();
                }

                this.service.Delete(item);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
