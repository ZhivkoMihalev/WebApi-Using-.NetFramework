namespace PariPlayCars.Services.DataServices
{
    using PariPlayCars.Data.Models;
    using PariPlayCars.Services.DataServices.Contracts;
    using PariPlayCars.Services.DataServices.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AbstractDbContext;

    public class CarService : ICarService
    {
        private readonly IAbstractDbContext _context;

        public CarService(AbstractDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            //var temp = await this._context.CarRepository.GetAllAsync();
            //var result = temp.Select(x => new CarDTO
            //{
            //    Brand = x.Brand,
            //    Model = x.Model,
            //    Year = x.Year
            //}).ToList();
            return (await this._context.CarRepository.GetAllAsync()).Select(x => new CarDTO
            {
                Brand = x.Brand,
                Model = x.Model,
                Year = x.Year
            }).ToList();
        }
        
        public async Task<CarDTO> GetByIdAsync(string id)
        {
            var car = await this._context.CarRepository.GetByIdAsync(id);
            if (car == null)
            {
                //TODO return message "A car with this id doesn't exist."
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

            if (this._context.CarRepository.GetAllAsync().Result
                .Any(x => x.Brand == newCar.Brand && x.Model == newCar.Model && x.Year == newCar.Year))
            {
                //TODO return message "already exist"
            }

            this._context.CarRepository.Add(newCar);
            await this ._context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var checkExistCar = this._context.CarRepository.GetByIdAsync(id).Result;
            if (checkExistCar == null)
            {
                //TODO return message "A car with this id doesn't exist!"
            }

            this._context.CarRepository.Remove(checkExistCar);
            await this._context.SaveChangesAsync();
        }

        public async Task Update(string id, CarDTO newCar)
        {
            var car = await this.GetByIdAsync(id);
            car.Brand = newCar.Brand;
            car.Model = newCar.Model;
            car.Year = newCar.Year;
            await this._context.SaveChangesAsync();
        }
    }
}
