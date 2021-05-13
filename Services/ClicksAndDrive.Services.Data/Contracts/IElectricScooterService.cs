namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;

    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public interface IElectricScooterService
    {
        IEnumerable<ElectricScooterViewModel> GetAll();
    }
}
