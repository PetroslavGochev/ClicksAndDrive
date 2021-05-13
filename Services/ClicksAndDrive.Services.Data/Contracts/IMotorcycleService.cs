namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;

    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public interface IMotorcycleService
    {
        IEnumerable<MotorcycleViewModel> GetAll();
    }
}
