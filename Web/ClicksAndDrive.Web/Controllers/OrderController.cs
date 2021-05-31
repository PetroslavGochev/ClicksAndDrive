namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this.orderService = orderService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> LoanVehicle(int vehicleId, string type)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var loan = new LoanOrderViewModel()
            {
                VehicleId = vehicleId,
                VehicleType = type,
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
