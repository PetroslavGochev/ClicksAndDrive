namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using ClicksAndDrive.Web.ViewModels.Orders;

    public interface IOrderService
    {
        Task LoanVehicle(LoanOrderViewModel input);
    }
}
