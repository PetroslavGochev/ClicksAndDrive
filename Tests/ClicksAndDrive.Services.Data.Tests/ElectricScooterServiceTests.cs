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
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class ElectricScooterServiceTests
    {
        [Fact]
        public async Task AddEScooterTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Add").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);

            var model = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var electricScooterTest = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(model);

            Assert.Equal(1, electricScooterTest);
        }

        [Fact]
        public async Task EditEScooterShouldEdit()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Edit").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);
            AutoMapperConfig.RegisterMappings(typeof(EditElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);

            var addModel = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var addedScooter = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(addModel);

            var editModel = new EditElectricScooterViewModel()
            {
                Made = "Edited",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            await electricScooterService.DoEdit<EditElectricScooterViewModel>(editModel);

            var editedModel = electricScooterService.EditDetails<EditElectricScooterViewModel>(addedScooter);

            Assert.Equal("Edited", editModel.Made);
        }

        [Fact]
        public async Task GetAllElectricScooterByType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all_by_type").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(ElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);

            var scooter1 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var scooter2 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var addedBycicle1 = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter1);
            var addedBycicle2 = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter2);

            var scooter = electricScooterService.GetAllByType<ElectricScooterViewModel>(string.Empty, false);

            Assert.Equal(2, scooter.ToList().Count);
        }

        [Fact]
        public async Task GetAllScooter()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("get_all").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(AddElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);

            var scooter1 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var scooter2 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var addedBycicle1 = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter1);
            var addedBycicle2 = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter2);

            var scooters = electricScooterService.GetAll<ElectricScooterViewModel>(false);

            Assert.Equal(2, scooters.ToList().Count);
        }

        [Fact]
        public async Task DeleteScooter()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("delete_bicycle").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(AddElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);

            var scooter1 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var scooter = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter1);

            await electricScooterService.Delete(scooter);

            var bycicles = electricScooterService.GetAll<ElectricScooterViewModel>(false);
            Assert.Empty(bycicles.ToList());
        }

        [Fact]
        public async Task AddImageToScooter()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("add_image").Options;
            var dbContext = new ApplicationDbContext(options);
            var imageService = new ImageService(dbContext);
            var electricScooterService = new ElectricScooterService(dbContext, imageService);

            AutoMapperConfig.RegisterMappings(typeof(ElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);
            AutoMapperConfig.RegisterMappings(typeof(EditElectricScooterViewModel).Assembly, typeof(ElectricScooter).Assembly);

            var scooter1 = new AddElectricScooterViewModel()
            {
                Made = "Xiomi",
                MaximumSpeed = 35,
                Mileage = 35,
                PriceForHour = 2.00M,
                Description = "Test",
            };

            var imagePath = "Test";
            var scooter = await electricScooterService.AddVehicle<AddElectricScooterViewModel>(scooter1);

            await electricScooterService.AddImageUrls(scooter, imagePath);

            var result = electricScooterService.EditDetails<ElectricScooterViewModel>(scooter);
            Assert.Equal(imagePath, result.ImageUrl);
        }
    }
}
