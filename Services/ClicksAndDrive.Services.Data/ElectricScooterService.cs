namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
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

        public IEnumerable<ElectricScooterViewModel> GetAll()
        {
            return this.db.ElectricScooters
                .Where(ec => ec.IsAvailable)
                .Select(ec => new ElectricScooterViewModel()
                {
                    Id = ec.Id,
                    Made = ec.Made,
                    PriceForHour = ec.PriceForHour,
                    ImageUrl = ec.ImageUrl,
                })
                .OrderBy(ec => ec.PriceForHour)
                .ToArray();
        }

        public async Task<int> AddElectricScooter(AddElectricScooterViewModel input)
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

        public ElectricScooter Details(int id)
        {
            return this.db.ElectricScooters.FirstOrDefault(es => es.Id == id);
        }

        public ElectricScooter Edit(int id)
        {
            return this.db.ElectricScooters.FirstOrDefault(b => b.Id == id);
        }

        public async Task DoEdit(EditElectricScooterViewModel input)
        {
            var electricScooter = this.db.ElectricScooters.FirstOrDefault(b => b.Id == input.Id);

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
            var electricScooter = this.db.ElectricScooters.FirstOrDefault(b => b.Id == id);

            if (electricScooter != null)
            {
                this.imageService.DeleteImage(electricScooter.ImageUrl);

                this.db.ElectricScooters.Remove(electricScooter);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var electrciScooter = this.db.ElectricScooters.FirstOrDefault(b => b.Id == id);

            if (electrciScooter != null)
            {
                electrciScooter.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }

        public decimal GetPrice(int id)
        {
            var electricScooter = this.db.ElectricScooters.FirstOrDefault(ec => ec.Id == id);

            return electricScooter.PriceForHour;
        }
    }
}
