namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;

    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public interface IBicycleService
    {
        IEnumerable<BicycleViewModel> GetAll();
    }
}
