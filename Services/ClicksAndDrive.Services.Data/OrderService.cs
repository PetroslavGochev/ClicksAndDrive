namespace ClicksAndDrive.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Data.Contracts;
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
                    PriceForHour = this.GetVehiclePrice(vehicle, input.VehicleId),
                    DateFrom = input.DateFrom,
                    IsCompleted = false,
                };

                user.Orders.Add(orders);

                await this.db.SaveChangesAsync();
            }
        }

        private decimal GetVehiclePrice(VehicleType type, int vehicleId) =>
            type switch
            {
                VehicleType.Bicycle => this.bicycleService.GetPrice(vehicleId),
                VehicleType.Car => this.carService.GetPrice(vehicleId),
                VehicleType.ElectricScooter => this.electricScooterService.GetPrice(vehicleId),
                VehicleType.Motorcycle => this.motorcycleService.GetPrice(vehicleId),
                _ => throw new InvalidOperationException("Invalid operation!"),
            };
    }
}
