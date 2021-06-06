namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.Administration.Orders;
    using ClicksAndDrive.Web.ViewModels.Orders;

    public interface IOrderService
    {
        Task LoanVehicle(LoanOrderViewModel input);

        IEnumerable<T> GetAll<T>(StatusType statusType);

        IEnumerable<T> UserOrders<T>(string id);

        T Details<T>(int id);

        Task EditLoan(int id, StatusType status);
    }
}
