namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public interface IElectricScooterService
    {
        IEnumerable<ElectricScooterViewModel> GetAll();

        int AddElectricScooter(AddElectricScooterViewModel input);

        ElectricScooter Details(int id);

        ElectricScooter Edit(int id);

        void DoEdit(EditElectricScooterViewModel input);

        void Delete(int id);

        void AddImageUrls(int id, string imageUrls);
    }
}
