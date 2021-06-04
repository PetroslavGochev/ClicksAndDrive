namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public interface IMotorcycleService : IVehicleService
    {
        Task<int> AddVehicle<T>(T input)
             where T : AddMotorcycleViewModel;

        Task DoEdit<T>(T input)
            where T : EditMotorcycleViewModel;
    }
}
