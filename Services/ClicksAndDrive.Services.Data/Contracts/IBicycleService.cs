namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public interface IBicycleService
    {
        IEnumerable<BicycleViewModel> GetAll(string type, bool isAdministrator);

        Task<int> AddBicycle(AddBycicleViewModel input);

        Bicycle Details(int id);

        Bicycle Edit(int id);

        Task DoEdit(EditBicycleViewModel input);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);

        decimal GetPrice(int id);
    }
}
