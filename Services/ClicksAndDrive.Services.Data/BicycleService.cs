namespace ClicksAndDrive.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.Bicycles;

    public class BicycleService : IBicycleService
    {
        private readonly ApplicationDbContext db;

        public BicycleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BicycleViewModel> GetAll(string type)
        {
            BicycleType bicycleType;
            Enum.TryParse<BicycleType>(type, out bicycleType);

            var bicycles = this.db.Bicycles
                .Where(b => b.IsAvailable && b.Type == bicycleType)
                .Select(b => new BicycleViewModel()
                {
                    Id = b.Id,
                    Made = b.Made,
                    PriceForHour = b.PriceForHour,
                    ImageUrl = b.ImageUrl,
                    Type = b.Type,
                    Size = b.Size,
                })
                .ToArray();

            return bicycles;
        }

        public Bicycle Details(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }

        public Bicycle Edit(int id)
        {
            return this.db.Bicycles.FirstOrDefault(b => b.Id == id);
        }

        public void DoEdit(EditBicycleViewModel input)
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

                this.db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            if (bicycle != null)
            {
                this.DeleteImage(bicycle.ImageUrl);

                this.db.Bicycles.Remove(bicycle);

                this.db.SaveChanges();
            }
        }

        public void AddImageUrls(int id, string imageUrls)
        {
            var bicycle = this.db.Bicycles.FirstOrDefault(b => b.Id == id);

            if (bicycle != null)
            {
                bicycle.ImageUrl = imageUrls;
                this.db.SaveChanges();
            }
        }

        public int AddBicycle(AddBycicleViewModel input)
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

            this.db.Bicycles.Add(bicycle);

            this.db.SaveChanges();

            return bicycle.Id;
        }

        private void DeleteImage(string imagePath)
        {
            if (imagePath != null)
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}