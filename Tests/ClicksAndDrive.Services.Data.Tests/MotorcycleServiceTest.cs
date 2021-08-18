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
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class MotorcycleServiceTest
    {
        [Fact]
        public async Task AddTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Add").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);

            var model = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var motorcycle = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(model);

            Assert.Equal(1, motorcycle);
        }

        [Fact]
        public async Task EditShouldEdit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Edit").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);
            AutoMapperConfig.RegisterMappings(typeof(EditMotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);

            var addModel = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var addedScooter = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(addModel);

            var editModel = new EditMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Edited",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            await motorcycleService.DoEdit<EditMotorcycleViewModel>(editModel);

            var editedModel = motorcycleService.EditDetails<EditMotorcycleViewModel>(addedScooter);

            Assert.Equal("Edited", editModel.Made);
        }

        [Fact]
        public async Task GetAllByType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_by_type").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(EditMotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);

            var scooter1 = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };
            var addedMotorcycle = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(scooter1);

            var scooter = motorcycleService.GetAllByType<MotorcycleViewModel>(MotorcycleType.Cross.ToString(), false);

            Assert.Single(scooter.ToList());
        }

        [Fact]
        public async Task GetAll()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(AddMotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);

            var scooter1 = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var addedBycicle1 = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(scooter1);

            var scooters = motorcycleService.GetAll<MotorcycleViewModel>(false);

            Assert.Single(scooters.ToList());
        }

        [Fact]
        public async Task Delete()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("delete_bicycle").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(AddMotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);

            var scooter1 = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var scooter = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(scooter1);

            await motorcycleService.Delete(scooter);

            var bycicles = motorcycleService.GetAll<MotorcycleViewModel>(false);
            Assert.Empty(bycicles.ToList());
        }

        [Fact]
        public async Task AddImage()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("add_image").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var motorcycleService = new MotorcycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(MotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(EditMotorcycleViewModel).Assembly, typeof(Motorcycle).Assembly);

            var scooter1 = new AddMotorcycleViewModel()
            {
                Type = MotorcycleType.Cross,
                Made = "Honda",
                Transmission = TransmissionType.Automatic,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var imagePath = "Test";
            var scooter = await motorcycleService.AddVehicle<AddMotorcycleViewModel>(scooter1);

            await motorcycleService.AddImageUrls(scooter, imagePath);

            var result = motorcycleService.EditDetails<MotorcycleViewModel>(scooter);
            Assert.Equal(imagePath, result.ImageUrl);
        }
    }
}
