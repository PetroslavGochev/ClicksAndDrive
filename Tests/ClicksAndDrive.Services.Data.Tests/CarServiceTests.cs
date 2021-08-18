namespace ClicksAndDrive.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Common.Repositories;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Data.Repositories;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class CarServiceTests
    {
        [Fact]
        public async Task AddCarTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests_Car").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);

            var model = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var car = await carService.AddVehicle<AddCarViewModel>(model);

            Assert.Equal(1, car);
        }

        [Fact]
        public async Task EditCarShouldEdit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Edit_Car").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);
            AutoMapperConfig.RegisterMappings(typeof(AddCarViewModel).Assembly, typeof(Car).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(EditCarViewModel).Assembly, typeof(Car).Assembly);

            var addCar = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle = await carService.AddVehicle<AddCarViewModel>(addCar);

            var editCar = new EditCarViewModel()
            {
                Id = addedBycicle,
                FuelType = FuelType.Diesel,
                Made = "Peugeot",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            await carService.DoEdit<EditCarViewModel>(editCar);

            var editCarResult = carService.EditDetails<EditCarViewModel>(addedBycicle);

            Assert.Equal("Peugeot", editCarResult.Made);
        }

        [Fact]
        public async Task GetAllCarsByType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_car_by_type").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(CarViewModel).Assembly, typeof(Car).Assembly);

            var car1 = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var car2 = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle1 = await carService.AddVehicle<AddCarViewModel>(car1);
            var addedBycicle2 = await carService.AddVehicle<AddCarViewModel>(car2);

            var cars = carService.GetAllByType<CarViewModel>(CarCategory.Sedan.ToString(), false);

            Assert.Equal(2, cars.ToList().Count);
        }

        [Fact]
        public async Task GetAllCars()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_car").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(CarViewModel).Assembly, typeof(Car).Assembly);

            var car1 = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var car2 = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle1 = await carService.AddVehicle<AddCarViewModel>(car1);
            var addedBycicle2 = await carService.AddVehicle<AddCarViewModel>(car2);

            var cars = carService.GetAll<CarViewModel>(false);

            Assert.Equal(2, cars.ToList().Count);
        }

        [Fact]
        public async Task DeleteCar()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("delete_car").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(CarViewModel).Assembly, typeof(Car).Assembly);

            var car = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var addedCar = await carService.AddVehicle<AddCarViewModel>(car);

            await carService.Delete(addedCar);

            var cars = carService.GetAll<CarViewModel>(false);
            Assert.Empty(cars.ToList());
        }

        [Fact]
        public async Task AddImageToCar()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("add_image_car").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var carService = new CarService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(BicycleViewModel).Assembly, typeof(Bicycle).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(EditBicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var car = new AddCarViewModel()
            {
                FuelType = FuelType.Diesel,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                Places = CarPlaces.Four,
                Category = CarCategory.Sedan,
                FuelConsumption = 5.0,
                Model = "Civic",
                PriceForHour = 21,
                Description = "Something",
            };

            var imagePath = "Test";
            var addedCar = await carService.AddVehicle<AddCarViewModel>(car);

            await carService.AddImageUrls(addedCar, imagePath);

            var result = carService.EditDetails<CarViewModel>(addedCar);
            Assert.Equal(imagePath, result.ImageUrl);
        }
    }
}
