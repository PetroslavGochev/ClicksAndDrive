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
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class BicycleServiceTests
    {
        [Fact]
        public async Task AddBicycleTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);

            var model = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var bicycle = await bicycleService.AddVehicle<AddBycicleViewModel>(model);

            Assert.Equal(1, bicycle);
        }

        [Fact]
        public async Task EditVechicleShouldEdit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Edit_tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);
            AutoMapperConfig.RegisterMappings(typeof(EditBicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var addBycicle = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle);

            var editBycicle = new EditBicycleViewModel()
            {
                Id = addedBycicle,
                Type = BicycleType.Mountain,
                Made = "Edited",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            await bicycleService.DoEdit<EditBicycleViewModel>(editBycicle);

            var editedBycicle = bicycleService.EditDetails<EditBicycleViewModel>(addedBycicle);

            Assert.Equal("Edited", editedBycicle.Made);
        }

        [Fact]
        public async Task GetAllBicyclesByType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_bycicles_by_type").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(BicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var addBycicle1 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle2 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something2",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle3 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something3",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle1 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle1);
            var addedBycicle2 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle2);
            var addedBycicle3 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle3);

            var bycicles = bicycleService.GetAllByType<BicycleViewModel>(BicycleType.Mountain.ToString(), false);

            Assert.Equal(3, bycicles.ToList().Count);
        }

        [Fact]
        public async Task GetAllBicycle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_bycicles").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(BicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var addBycicle1 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle2 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something2",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle3 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something3",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle1 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle1);
            var addedBycicle2 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle2);
            var addedBycicle3 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle3);

            var bycicles = bicycleService.GetAll<BicycleViewModel>(false);

            Assert.Equal(3, bycicles.ToList().Count);
        }

        [Fact]
        public async Task DeleteBicycle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("delete_bicycle").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(BicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var addBycicle1 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle2 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something2",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addBycicle3 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something3",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var addedBycicle1 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle1);
            var addedBycicle2 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle2);
            var addedBycicle3 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle3);

            await bicycleService.Delete(addedBycicle2);

            var bycicles = bicycleService.GetAll<BicycleViewModel>(false);
            Assert.Equal(2, bycicles.ToList().Count);
        }

        [Fact]
        public async Task AddImageToBicycle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("add_image").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(BicycleViewModel).Assembly, typeof(Bicycle).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(EditBicycleViewModel).Assembly, typeof(Bicycle).Assembly);

            var addBycicle1 = new AddBycicleViewModel()
            {
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
            };

            var imagePath = "Test";
            var addedBycicle1 = await bicycleService.AddVehicle<AddBycicleViewModel>(addBycicle1);

            await bicycleService.AddImageUrls(addedBycicle1, imagePath);

            var bycicles = bicycleService.GetAll<BicycleViewModel>(false);
            var result = bicycleService.EditDetails<BicycleViewModel>(addedBycicle1);
            Assert.Equal(imagePath, result.ImageUrl);
        }
    }
}
