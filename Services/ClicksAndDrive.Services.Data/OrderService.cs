namespace ClicksAndDrive.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.Orders;

    public class OrderService : IOrderService
    {
        private readonly IBicycleService bicycleService;
        private readonly ICarService carService;
        private readonly IElectricScooterService electricScooterService;
        private readonly IMotorcycleService motorcycleService;
        private readonly ApplicationDbContext db;

        public OrderService(
                               IBicycleService bicycleService,
                               ICarService carService,
                               IElectricScooterService electricScooterService,
                               IMotorcycleService motorcycleService,
                               ApplicationDbContext db)
        {
            this.bicycleService = bicycleService;
            this.carService = carService;
            this.electricScooterService = electricScooterService;
            this.motorcycleService = motorcycleService;
            this.db = db;
        }

        public IEnumerable<T> GetAll<T>(StatusType statusType)
        {
            return this.db.Orders.Where(o => o.Status == statusType)
                .To<T>()
                .ToArray();
        }

        public async Task LoanVehicle(LoanOrderViewModel input)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == input.UserId);

            if (user != null)
            {
                VehicleType vehicle;
                Enum.TryParse<VehicleType>(input.VehicleType, out vehicle);

                var orders = new Order()
                {
                    VehicleType = vehicle,
                    VehicleId = input.VehicleId,
                    Address = input.Address,
                    PriceForHour = input.PriceForHour,
                    DateFrom = input.DateFrom,
                    Status = StatusType.Wait,
                };

                user.Orders.Add(orders);

                await this.db.SaveChangesAsync();
            }
        }

        public IEnumerable<T> UserOrders<T>(string id)
        {
            return this.db.Orders.Where(u => u.UserId == id)
                 .OrderByDescending(u => u.DateFrom)
                 .To<T>()
                 .ToArray();
        }
    }
}
