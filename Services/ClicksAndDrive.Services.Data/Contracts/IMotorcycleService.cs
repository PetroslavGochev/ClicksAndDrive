namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public interface IMotorcycleService
    {
        IEnumerable<MotorcycleViewModel> GetAll(string type);

        Task<int> AddMotorcycle(AddMotorcycleViewModel input);

        Motorcycle Details(int id);

        Motorcycle Edit(int id);

        Task DoEdit(EditMotorcycleViewModel input);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);

        decimal GetPrice(int id);
    }
}
