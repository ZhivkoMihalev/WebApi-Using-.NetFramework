namespace PariPlayCars.Services.DataServices
{
    using PariPlayCars.Data.Common;
    using PariPlayCars.Data.Models;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly IRepository<Car> carRepository;

        public CarService(IRepository<Car> carRepo)
        {
            this.carRepository = carRepo;
        }

        public Task<IEnumerable<CarDTO>> All()
        {
            return Task.FromResult(this.carRepository.All()
                .GetAwaiter()
                .GetResult()
                .Select(x => new CarDTO { Brand = x.Brand, Model = x.Model, Year = x.Year }));
        }

        public async Task Create(CarDTO car)
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

                await this.carRepository.Add(newCar);
                await this.carRepository.SaveChangesAsync();
            }
        }

        public async Task Delete(string id)
        {
            var currentCar = await this.carRepository.GetByIdAsync(id);
            if (currentCar != null)
            {
                await this.carRepository.Remove(currentCar);
                await this.carRepository.SaveChangesAsync();
            }
        }

        public async Task<CarDTO> GetById(string id)
        {
            var car = await this.carRepository.GetByIdAsync(id);
            if (car != null)
            {
                return new CarDTO { Brand = car.Brand, Model = car.Model, Year = car.Year };
            }

            else
            {
                return null;
            }
        }

        public Task<IEnumerable<CarDTO>> Search(string search)
        {
            return Task.FromResult(this.carRepository.All()
                .GetAwaiter()
                .GetResult()
                .Where(x => x.Brand.StartsWith(search) || x.Model.StartsWith(search))
                .Select(x => new CarDTO { Brand = x.Brand, Model = x.Model, Year = x.Year }));
        }

        public bool Exist(CarDTO car)
        {
            return this.carRepository.All().Result.Any(c => c.Brand == car.Brand && c.Model == car.Model && c.Year == car.Year);
        }
    }
}
