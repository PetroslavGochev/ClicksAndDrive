namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;

    public class ElectricScooterService : IElectricScooterService
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService imageService;

        public ElectricScooterService(ApplicationDbContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }

        public async Task<int> AddVehicle<T>(T input)
            where T : AddElectricScooterViewModel
        {
            var electricScooter = new ElectricScooter()
            {
                Made = input.Made,
                MaximumSpeed = input.MaximumSpeed,
                Mileage = input.Mileage,
                IsAvailable = true,
                PriceForHour = input.PriceForHour,
                Description = input.Description,
            };

            await this.db.ElectricScooters.AddAsync(electricScooter);

            await this.db.SaveChangesAsync();

            return electricScooter.Id;
        }

        public T EditDetails<T>(int id)
        {
            return this.db.ElectricScooters
              .Where(b => b.Id == id)
              .To<T>()
              .First();
        }

        public IEnumerable<T> GetAll<T>(string type, bool isAdministrator)
        {
            var electrciScooter = this.db.ElectricScooters
                .Where(ec => (!isAdministrator ? ec.IsAvailable : ec.IsAvailable || !ec.IsAvailable))
                .OrderByDescending(ec => ec.PriceForHour)
                .To<T>()
                .ToArray();

            return electrciScooter;
        }

        public async Task DoEdit<T>(T input)
             where T : EditElectricScooterViewModel
        {
            var electricScooter = this.db.ElectricScooters.FirstOrDefault(ec => ec.Id == input.Id);

            if (electricScooter != null)
            {
                electricScooter.Made = input.Made;
                electricScooter.MaximumSpeed = input.MaximumSpeed;
                electricScooter.Mileage = input.Mileage;
                electricScooter.PriceForHour = input.PriceForHour;
                electricScooter.IsAvailable = input.IsAvailable;
                electricScooter.Description = input.Description;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var electricScooter = this.db.ElectricScooters.FirstOrDefault(ec => ec.Id == id);

            if (electricScooter != null)
            {
                this.imageService.DeleteImage(electricScooter.ImageUrl);

                this.db.ElectricScooters.Remove(electricScooter);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var electrciScooter = this.db.ElectricScooters.FirstOrDefault(ec => ec.Id == id);

            if (electrciScooter != null)
            {
                electrciScooter.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }
    }
}
