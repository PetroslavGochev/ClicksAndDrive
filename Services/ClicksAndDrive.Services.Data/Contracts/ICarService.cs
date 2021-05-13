namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;

    using ClicksAndDrive.Web.ViewModels.Cars;

    public interface ICarService
    {
        IEnumerable<CarViewModel> GetAll();
    }
}
