namespace PariPlayCars.Services.DataServices
{
    using PariPlayCars.Data.Common;
    using PariPlayCars.Data.Models;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;

        public CarService(IRepository<Car> carRepo)
        {
            this.carRepository = carRepo;
        }

        public IEnumerable<CarDTO> All()
        {
            return this.carRepository.All()
                .Select(c => new CarDTO
                {
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year
                })
                .ToArray();
        }

        public async void Create(CarDTO car)
        {
            var check = Exist(car);
            if (!check)
            {
                var newCar = new Car
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year
                };

                this.carRepository.Add(newCar);
                await this.carRepository.SaveChangesAsync();
            }
        }

        public async void Delete(CarDTO car)
        {
            var currentCar = this.carRepository
                .All()
                .FirstOrDefault(x => x.Brand == car.Brand && x.Model == car.Model && x.Year == car.Year);

            if (currentCar != null)
            {
                this.carRepository.Delete(currentCar);
                await this .carRepository.SaveChangesAsync();
            }
        }

        public CarDTO GetById(string id)
        {
            var car = this.carRepository.GetByIdAsync(id).Result;
            if (car != null)
            {
                return new CarDTO { Brand = car.Brand, Model = car.Model, Year = car.Year };
            }

            else
            {
                return null;
            }
        }

        public IEnumerable<CarDTO> Search(string search)
        {
            return this.carRepository.All()
                .Where(x => x.Brand == search || x.Model == search)
                .Select(c => new CarDTO
                {
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year
                })
                .ToList();
        }

        public bool Exist(CarDTO car)
        {
            return this.carRepository.All().Any(c => c.Brand == car.Brand && c.Model == car.Model && c.Year == car.Year);
        }
    }
}
