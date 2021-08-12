namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IVehicleService
    {
        IEnumerable<T> GetAllByType<T>(string type, bool isAdministrator);

        IEnumerable<T> GetAll<T>(bool isAdministrator);

        T EditDetails<T>(int id);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);
    }
}
