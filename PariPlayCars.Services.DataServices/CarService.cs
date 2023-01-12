namespace PariPlayCars.Services.DataServices
{
    using PariPlayCars.Data.Models;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;
    
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PariPlayCars.Data.ApplicationExceptions;
    using PariPlayCars.Data.Utils;
    using PariPlayCars.Data;

    public class CarService : ICarService
    {
        private readonly CarRepository _carRepository;

        public CarService(CarRepository repository)
        {
            this._carRepository = repository;
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            var temp = await this._carRepository.GetAllAsync();
            var result = temp.Select(x => new CarDTO
            {
                Brand = x.Brand,
                Model = x.Model,
                Year = x.Year
            }).ToList();

            return result;
        }
        
        public async Task<CarDTO> GetByIdAsync(string id)
        {
            var car = await this._carRepository.GetByIdAsync(id);
            if (car == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.CarNotFound);
            }

            var returnCar = new CarDTO
            {
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year
            };

            return returnCar;
        }

        public async Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            var temp = await this.GetAllAsync();
            var result = temp.Where(c => c.Brand == search).ToList();
            return result;
        }
        
        public async Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            var temp = await this.GetAllAsync();
            var result = temp.Where(c => c.Model == search).ToList();
            return result;
        }
        
        public async Task CreateAsync(CarDTO car)
        {
            var newCar = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year
            };

            if (this._carRepository.GetAllAsync().Result
                .Any(x => x.Brand == newCar.Brand && x.Model == newCar.Model && x.Year == newCar.Year))
            {
                throw new EntityAlreadyExistsException(ExceptionMessages.CarAlreadyExist);
            }

            this._carRepository.Add(newCar);
            await this._carRepository.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var checkExistCar = this._carRepository.GetByIdAsync(id).Result;
            if (checkExistCar == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.CarNotFound);
            }

            this._carRepository.Remove(checkExistCar);
            await this._carRepository.SaveChangesAsync();
        }

        public async Task Update(string id, CarDTO newCar)
        {
            var car = await this.GetByIdAsync(id);
            if (car == null)
            {
                throw new EntityNotFoundException(ExceptionMessages.CarNotFound);
            }

            car.Brand = newCar.Brand;
            car.Model = newCar.Model;
            car.Year = newCar.Year;
            await this._carRepository.SaveChangesAsync();
        }
    }
}
