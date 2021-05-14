namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public interface IMotorcycleService
    {
        IEnumerable<MotorcycleViewModel> GetAll();

        Motorcycle Details(int id);
    }
}
