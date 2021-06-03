namespace ClicksAndDrive.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> LoanVehicle(int vehicleId, string type, decimal priceForHour)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var loan = new LoanOrderViewModel()
            {
                VehicleId = vehicleId,
                VehicleType = type,
                PriceForHour = priceForHour,
                DateFrom = DateTime.UtcNow,
                Address = user.Address,
                UserId = user.Id,
            };

            return this.View(loan);
        }

        [HttpPost]
        public async Task<IActionResult> LoanVehicle(LoanOrderViewModel input)
        {
            await this.orderService.LoanVehicle(input);

            return this.View();
        }
    }
}
