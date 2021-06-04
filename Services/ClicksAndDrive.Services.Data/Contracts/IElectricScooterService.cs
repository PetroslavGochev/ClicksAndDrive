namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public interface IElectricScooterService : IVehicleService
    {
        Task<int> AddVehicle<T>(T input)
            where T : AddElectricScooterViewModel;

        Task DoEdit<T>(T input)
            where T : EditElectricScooterViewModel;
    }
}
