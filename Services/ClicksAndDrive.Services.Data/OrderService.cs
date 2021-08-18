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
        private const int DISCOUNT = 100;
        private const int NULL = 0;

        private readonly ApplicationDbContext db;
        private readonly IUserService userService;

        public OrderService(
                               ApplicationDbContext db,
                               IUserService userService)
        {
            this.db = db;
            this.userService = userService;
        }

        public T Details<T>(int id)
        {
            return this.db.Orders
                 .Where(x => x.Id == id)
                 .To<T>()
                 .FirstOrDefault();
        }

        public async Task EditLoan(int id, StatusType status)
        {
            var order = this.db.Orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                if (status == StatusType.Rejected)
                {
                    order.Status = StatusType.Rejected;
                    await this.ChangeVehicleAvailable(order.VehicleId, order.VehicleType);
                }
                else if (status == StatusType.Finished)
                {
                    order.Status = StatusType.Finished;
                    order.DateTo = DateTime.Now;

                    var hours = Math.Ceiling(((DateTime)order.DateTo - order.DateFrom).TotalHours);

                    order.TotalSum = order.PriceForHour * (decimal)hours;

                    var user = this.userService.GetCurrentUsers(order.UserId);

                    if (this.userService.GetCurrentUsers(order.UserId).Discount != NULL)
                    {
                        order.TotalSum -= order.TotalSum * order.User.Discount / DISCOUNT;
                    }

                    await this.ChangeVehicleAvailable(order.VehicleId, order.VehicleType);
                    await this.userService.UpdateUserDiscount(user.Id);
                }
                else if (status == StatusType.Accepted)
                {
                    order.Status = StatusType.Accepted;
                }

                await this.db.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(StatusType statusType)
        {
            return this.db.Orders.Where(o => o.Status == statusType)
                .OrderByDescending(u => u.DateFrom)
                .To<T>()
                .ToArray();
        }

        public async Task LoanVehicle(LoanOrderViewModel input)
        {
            var user = this.userService.GetCurrentUsers(input.UserId);

            if (user != null)
            {
                VehicleType vehicle;
                Enum.TryParse<VehicleType>(input.VehicleType, out vehicle);

                await this.ChangeVehicleAvailable(input.VehicleId, vehicle);
                await this.userService.UpdateUserFirstAndLastName(input.UserId, input.FirstName, input.LastName);

                var orders = new Order()
                {
                    VehicleType = vehicle,
                    VehicleId = input.VehicleId,
                    Address = input.Address,
                    PriceForHour = input.PriceForHour,
                    DateFrom = input.DateFrom,
                    Status = StatusType.Wait,
                    ImageUrl = this.GetVehicleImage(input.VehicleId, vehicle),
                    User = this.userService.GetCurrentUsers(input.UserId),
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

        private async Task ChangeVehicleAvailable(int id, VehicleType vehicle)
        {
            if (vehicle == VehicleType.Bicycle)
            {
                var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

                bicycle.IsAvailable = bicycle.IsAvailable ? false : true;
            }
            else if (vehicle == VehicleType.Car)
            {
                var car = this.db.Cars.FirstOrDefault(b => b.Id == id);

                car.IsAvailable = car.IsAvailable ? false : true;
            }
            else if (vehicle == VehicleType.ElectricScooter)
            {
                var electricScooter = this.db.Cars.FirstOrDefault(b => b.Id == id);

                electricScooter.IsAvailable = electricScooter.IsAvailable ? false : true;
            }
            else if (vehicle == VehicleType.Motorcycle)
            {
                var motorcycle = this.db.Cars.FirstOrDefault(b => b.Id == id);

                motorcycle.IsAvailable = motorcycle.IsAvailable ? false : true;
            }

            await this.db.SaveChangesAsync();
        }

        private string GetVehicleImage(int id, VehicleType vehicleType)
        {
            string imagePath = string.Empty;

            if (vehicleType == VehicleType.Bicycle)
            {
                var bicycle = this.db.Bicycles
                    .FirstOrDefault(b => b.Id == id);

                imagePath = bicycle.ImageUrl;
            }
            else if (vehicleType == VehicleType.Car)
            {
                var car = this.db.Cars
                    .FirstOrDefault(b => b.Id == id);

                imagePath = car.ImageUrl;
            }
            else if (vehicleType == VehicleType.ElectricScooter)
            {
                var escooter = this.db.ElectricScooters
                   .FirstOrDefault(b => b.Id == id);

                imagePath = escooter.ImageUrl;
            }
            else
            {
                var motorcycle = this.db.Motorcycles
                   .FirstOrDefault(b => b.Id == id);

                imagePath = motorcycle.ImageUrl;
            }

            return imagePath;
        }
    }
}
