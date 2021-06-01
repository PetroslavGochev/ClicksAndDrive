namespace ClicksAndDrive.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public class BicycleService : IBicycleService
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService imageService;

        public BicycleService(ApplicationDbContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }

        public IEnumerable<BicycleViewModel> GetAll(string type, bool isAdministrator)
        {
            BicycleType bicycleType;
            Enum.TryParse<BicycleType>(type, out bicycleType);

            var bicycles = this.db.Bicycles
                .Where(b => (!isAdministrator ? b.IsAvailable : b.IsAvailable || !b.IsAvailable) && b.Type == bicycleType)
                .Select(b => new BicycleViewModel()
                {
                    Id = b.Id,
                    Made = b.Made,
                    PriceForHour = b.PriceForHour,
                    ImageUrl = b.ImageUrl,
                    Type = b.Type,
                    Size = b.Size,
                })
                .OrderBy(b => b.PriceForHour)
                .ToArray();

            return bicycles;
        }

        public async Task<int> AddBicycle(AddBycicleViewModel input)
        {
            var bicycle = new Bicycle()
            {
                Type = input.Type,
                Made = input.Made,
                Speeds = input.Speeds,
                Size = input.Size,
                SizeOfTires = input.SizeOfTires,
                IsAvailable = true,
                PriceForHour = input.PriceForHour,
                Description = input.Description,
            };

            await this.db.Bicycles.AddAsync(bicycle);

            await this.db.SaveChangesAsync();

            return bicycle.Id;
        }

        public Bicycle Details(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }

        public Bicycle Edit(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }

        public async Task DoEdit(EditBicycleViewModel input)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == input.Id);

            if (bicycle != null)
            {
                bicycle.Made = input.Made;
                bicycle.Type = input.Type;
                bicycle.Speeds = input.Speeds;
                bicycle.PriceForHour = input.PriceForHour;
                bicycle.Size = input.Size;
                bicycle.IsAvailable = input.IsAvailable;
                bicycle.SizeOfTires = input.SizeOfTires;
                bicycle.Description = input.Description;

                await this.db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            if (bicycle != null)
            {
                if (bicycle.ImageUrl != null)
                {
                    this.imageService.DeleteImage(bicycle.ImageUrl);
                }

                this.db.Bicycles.Remove(bicycle);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            if (bicycle != null)
            {
                bicycle.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }

        public decimal GetPrice(int id)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            return bicycle.PriceForHour;
        }
    }
}
