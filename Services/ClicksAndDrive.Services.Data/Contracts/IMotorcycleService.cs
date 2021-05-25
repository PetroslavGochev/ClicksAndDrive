namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public interface IMotorcycleService
    {
        IEnumerable<MotorcycleViewModel> GetAll(string type);

        int AddMotorcycle(AddMotorcycleViewModel input);

        Motorcycle Details(int id);

        Motorcycle Edit(int id);

        void DoEdit(EditMotorcycleViewModel input);

        void Delete(int id);

        void AddImageUrls(int id, string imageUrls);
    }
}
