namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public interface IElectricScooterService
    {
        IEnumerable<ElectricScooterViewModel> GetAll();

        Task<int> AddElectricScooter(AddElectricScooterViewModel input);

        ElectricScooter Details(int id);

        ElectricScooter Edit(int id);

        Task DoEdit(EditElectricScooterViewModel input);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);

        decimal GetPrice(int id);
    }
}
