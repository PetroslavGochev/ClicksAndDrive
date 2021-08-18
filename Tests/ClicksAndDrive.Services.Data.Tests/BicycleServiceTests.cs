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
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class BicycleServiceTests
    {
        [Fact]
        public async Task AddVehicleShouldAddVehicle ()
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
    }
}
