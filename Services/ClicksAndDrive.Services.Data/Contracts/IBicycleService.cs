namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public interface IBicycleService : IVehicleService
    {
        Task<int> AddVehicle<T>(T input)
            where T : AddBycicleViewModel;

        Task DoEdit<T>(T input)
            where T : EditBicycleViewModel;
    }
}
