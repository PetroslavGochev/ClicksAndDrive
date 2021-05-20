namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public interface ICarService
    {
        int AddCar(AddCarViewModel input);

        IEnumerable<CarViewModel> GetAll(string[] category, string[] places, string[] transmissions, string[] fuelType);

        Car Details(int id);

        Car Edit(int id);

        void DoEdit(EditCarViewModel input);

        void Delete(int id);

        void AddImageUrls(int id, string imageUrls);
    }
}
