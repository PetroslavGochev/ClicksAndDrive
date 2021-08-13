namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using ClicksAndDrive.Data.Models;

    public interface IUserService
    {
        ApplicationUser GetCurrentUsers(string id);

        Task UpdateUserDiscount(string id);

        Task UpdateUserFirstAndLastName(string id, string firstName, string lastName);
    }
}
