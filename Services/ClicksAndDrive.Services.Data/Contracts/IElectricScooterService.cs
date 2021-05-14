namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public interface IElectricScooterService
    {
        IEnumerable<ElectricScooterViewModel> GetAll();

        ElectricScooter Details(int id);
    }
}
