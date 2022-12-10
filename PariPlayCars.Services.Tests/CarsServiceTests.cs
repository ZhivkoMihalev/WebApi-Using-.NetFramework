using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PariPlayCars.Data.Common;
using PariPlayCars.Data.Models;
using PariPlayCars.Services.DataServices;
using PariPlayCars.Services.DataServices.Models;

namespace PariPlayCars.Services.Tests
{
    [TestClass]
    public class CarsServiceTests
    {
        [TestMethod]
        public async Task CreateMethodShouldCreateAnObjectCar()
        {
            var car1 = new CarDTO { Brand = "BMW", Model = "530d", Year = 1999 };
            var car2 = new CarDTO { Brand = "Audi", Model = "A4", Year = 2010 };
            var carsList = new List<Car>();
            var mockRepo = new Mock<IRepository<Car>>();
            mockRepo.Setup(x => x.Add(It.IsAny<Car>())).Callback((Car car) => carsList.Add(car));

            var service = new CarService(mockRepo.Object);
            await service.Create(car1);
            await service.Create(car2);
            Assert.AreEqual(2, carsList.Count);
        }

        [TestMethod]
        public async Task DeleteMethodShouldRemoveObjectCar()
        {
            var carsList = new List<Car>
            {
                new Car { Id = new Guid(), Brand = "BMW", Model = "530d", Year = 1999 },
                new Car { Id = new Guid(), Brand = "Audi", Model = "A4", Year = 2010 }
            };

            var mockRepo = new Mock<IRepository<Car>>();
            mockRepo.Setup(x => x.Remove(It.IsAny<Car>())).Callback((Car car) => carsList.Remove(car));

            var service = new CarService(mockRepo.Object);
            await service.Delete(carsList.First().Id.ToString());
            Assert.AreEqual(1, service.All().Result.Count());
        }
    }
}
