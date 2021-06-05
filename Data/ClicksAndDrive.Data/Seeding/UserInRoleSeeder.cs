namespace ClicksAndDrive.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UserInRoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserInRoles(userManager, GlobalConstants.AdministratorRoleName);
        }

        private static async Task SeedUserInRoles(UserManager<ApplicationUser> userManager, string roleName)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "AdminFirstName",
                    LastName = "AdminLastName",
                    PhoneNumber = "0889636769",
                    Age = 30,
                    Discount = 100,
                };

                var password = "admin123";

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
