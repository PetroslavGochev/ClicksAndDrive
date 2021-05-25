namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public interface ICarService
    {
        IEnumerable<CarViewModel> GetAll(string type);

        int AddCar(AddCarViewModel input);

        Car Details(int id);

        Car Edit(int id);

        void DoEdit(EditCarViewModel input);

        void Delete(int id);

        void AddImageUrls(int id, string imageUrls);
    }
}
