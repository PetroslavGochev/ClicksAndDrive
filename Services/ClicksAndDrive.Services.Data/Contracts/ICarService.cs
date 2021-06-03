namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public interface ICarService : IVehicleService
    {
        Task<int> AddVehicle<T>(T input)
              where T : AddCarViewModel;

        Task DoEdit<T>(T input)
            where T : EditCarViewModel;
    }
}
