namespace ClicksAndDrive.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVehicleService
    {
        IEnumerable<T> GetAll<T>(string type, bool isAdministrator);

        T EditDetails<T>(int id);

        Task Delete(int id);

        Task AddImageUrls(int id, string imageUrls);
    }
}
