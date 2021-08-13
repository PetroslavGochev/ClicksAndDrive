namespace ClicksAndDrive.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Administration.Orders;
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

        public async Task<IActionResult> LoanVehicle(VehicleDataViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var loan = new LoanOrderViewModel()
            {
                VehicleId = input.VehicleId,
                VehicleType = input.Type.ToString(),
                PriceForHour = input.PriceForHour,
                DateFrom = DateTime.Now,
                UserId = user.Id,
                ImageUrl = input.ImageUrl,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };

            return this.View(loan);
        }

        [HttpPost]
        public async Task<IActionResult> LoanVehicle(LoanOrderViewModel input)
        {
            await this.orderService.LoanVehicle(input);

            return this.RedirectToAction(nameof(this.UserOrders));
        }

        public async Task<IActionResult> UserOrders()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var orders = this.orderService.UserOrders<OrdersViewModel>(user.Id);

            return this.View(orders);
        }

        public IActionResult DetailOrders(int id)
        {
            var detailOrder = this.orderService.Details<DetailsOrderViewModel>(id);
            ;
            return this.View(detailOrder);
        }
    }
}
