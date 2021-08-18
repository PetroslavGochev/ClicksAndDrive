namespace ClicksAndDrive.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Common.Repositories;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Data.Repositories;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.Administration.Orders;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using ClicksAndDrive.Web.ViewModels.Orders;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class OrderServiceTests
    {
        [Fact]
        public async Task LoanVehicle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var userService = new UserService(dbContext);
            var orderService = new OrderService(dbContext, userService);
            var imageService = new ImageService(dbContext);
            var bicycleService = new BicycleService(dbContext, imageService);
            AutoMapperConfig.RegisterMappings(typeof(LoanOrderViewModel).Assembly, typeof(Order).Assembly);

            var vehicle = new Bicycle()
            {
                Id = 1,
                Type = BicycleType.Mountain,
                Made = "Something",
                Speeds = 21,
                Size = BicycleSize.M,
                SizeOfTires = 21,
                PriceForHour = 21,
                Description = "Something",
                ImageUrl = "Test",
            };
            var user = new ApplicationUser()
            {
                Id = "Test",
                FirstName = "Petroslav",
                LastName = "Gochev",
                Email = "petroslavGochev@abv.bg",
                PhoneNumber = "0889636768",
                Age = 24,
            };

            dbContext.Add<ApplicationUser>(user);
            dbContext.Add<Bicycle>(vehicle);

            var orders = new LoanOrderViewModel()
            {
                VehicleId = 1,
                VehicleType = BicycleType.Mountain.ToString(),
                UserId = "Test",
                Address = "Stara Planina",
                DateFrom = DateTime.Now,
                UserName = "petroslavGochev@abv.bg",
                FirstName = "Petroslav",
                LastName = "Gochev",
                Email = "petroslavGochev@abv.bg",
                ImageUrl = "Gochev",
            };

            await orderService.LoanVehicle(orders);

            Assert.Empty(user.Orders);
        }

        //[Fact]
        //public async Task EditLoan()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
        //    var dbContext = new ApplicationDbContext(options);
        //    var userService = new UserService(dbContext);
        //    var orderService = new OrderService(dbContext, userService);
        //    AutoMapperConfig.RegisterMappings(typeof(OrdersViewModel).Assembly, typeof(Order).Assembly);
        //    AutoMapperConfig.RegisterMappings(typeof(DetailsOrderViewModel).Assembly, typeof(Order).Assembly);

        //    var order = new Order()
        //    {
        //        Id = 1,
        //        UserId = "1",
        //        VehicleId = 2,
        //        Address = "Stara Planina",
        //        Status = StatusType.Wait,
        //        DateFrom = DateTime.Now,
        //        ImageUrl = "Test",
        //        PriceForHour = 2.00M,
        //        VehicleType = VehicleType.Motorcycle,
        //    };
        //    dbContext.Add<Order>(order);

        //    await orderService.EditLoan(1, StatusType.Accepted);
        //    await orderService.EditLoan(1, StatusType.Finished);
        //    await orderService.EditLoan(1, StatusType.Rejected);

        //    var test = orderService.Details<DetailsOrderViewModel>(1);
        //    Assert.NotNull(test);
        //}

        [Fact]
        public void GetAllOrders()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var userService = new UserService(dbContext);
            var orderService = new OrderService(dbContext, userService);
            AutoMapperConfig.RegisterMappings(typeof(OrdersViewModel).Assembly, typeof(Order).Assembly);

            var orders = orderService.GetAll<OrdersViewModel>(StatusType.Accepted);

            Assert.Empty(orders);
        }

        [Fact]
        public void DetailsOrders()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var userService = new UserService(dbContext);
            var orderService = new OrderService(dbContext, userService);
            AutoMapperConfig.RegisterMappings(typeof(DetailsOrderViewModel).Assembly, typeof(Order).Assembly);

            var orders = orderService.Details<DetailsOrderViewModel>(1);

            Assert.Null(orders);
        }

        [Fact]
        public void UserOrders()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var userService = new UserService(dbContext);
            var orderService = new OrderService(dbContext, userService);
            AutoMapperConfig.RegisterMappings(typeof(OrdersViewModel).Assembly, typeof(Order).Assembly);

            var orders = orderService.UserOrders<OrdersViewModel>("1");

            Assert.Empty(orders);
        }
    }
}
