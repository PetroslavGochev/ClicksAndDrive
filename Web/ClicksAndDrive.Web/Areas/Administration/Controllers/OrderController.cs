namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Administration.Orders;
    using Microsoft.AspNetCore.Mvc;

    public class OrderController : AdministrationController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult Orders(StatusType type)
        {
            var orders = this.orderService.GetAll<OrdersViewModel>(type);

            return this.View(orders);
        }

        public async Task<IActionResult> LoanEdit(int id, StatusType status)
        {
            await this.orderService.EditLoan(id, status);

            return this.Redirect($"/Order/DetailOrders/{id}");
        }
    }
}
