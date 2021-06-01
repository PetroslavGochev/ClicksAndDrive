namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public interface ICarService
    {
        IEnumerable<CarViewModel> GetAll(string type, bool isAdministrator);

        Task<int> AddCar(AddCarViewModel input);

        Car Details(int id);

        Car Edit(int id);

        Task DoEdit(EditCarViewModel input);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);

        decimal GetPrice(int id);
    }
}
