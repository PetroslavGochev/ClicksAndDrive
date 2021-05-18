namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public interface IBicycleService
    {
        int AddBicycle(AddBycicleViewModel input);

        IEnumerable<BicycleViewModel> GetAll(string[] size, string[] type);

        Bicycle Details(int id);

        Bicycle Edit(int id);

        void DoEdit(EditBicycleViewModel input);

        void Delete(int id);

        void AddImageUrls(int id, string imageUrls);
    }
}
