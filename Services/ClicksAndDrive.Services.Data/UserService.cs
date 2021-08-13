namespace ClicksAndDrive.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;

    public class UserService : IUserService
    {
        private const int DISCOUNT = 100;
        private const int MAXIMUMDISCOUNT = 50;
        private const int MULTIPLY = 5;
        private const int NULL = 0;

        private readonly ApplicationDbContext db;

        public UserService(
            ApplicationDbContext db)
        {
            this.db = db;
        }

        public ApplicationUser GetCurrentUsers(string id)
        {
            return this.db.Users
                          .FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateUserDiscount(string id)
        {
            var user = this.GetCurrentUsers(id);

            var discountCount = this.db.Orders.Where(x => x.UserId == id).ToList().Count;

            if (user.Discount < MAXIMUMDISCOUNT && discountCount % MULTIPLY == NULL)
            {
                user.Discount = (byte)user.Orders.Count;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task UpdateUserFirstAndLastName(string id, string firstName, string lastName)
        {
            var user = this.GetCurrentUsers(id);

            if (user.FirstName != firstName || user.LastName != lastName)
            {
                user.FirstName = firstName;
                user.LastName = lastName;

                await this.db.SaveChangesAsync();
            }
        }
    }
}
