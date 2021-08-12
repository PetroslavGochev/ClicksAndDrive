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
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;

    public class MotorcycleService : IMotorcycleService
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService imageService;

        public MotorcycleService(ApplicationDbContext db, IImageService imageService)
        {
            this.db = db;
            this.imageService = imageService;
        }

        public async Task<int> AddVehicle<T>(T input)
            where T : AddMotorcycleViewModel
        {
            var motorcycle = new Motorcycle()
            {
                Type = input.Type,
                Made = input.Made,
                IsAvailable = true,
                Transmission = input.Transmission,
                PriceForHour = input.PriceForHour,
                Description = input.Description,
            };

            await this.db.Motorcycles.AddAsync(motorcycle);

            await this.db.SaveChangesAsync();

            return motorcycle.Id;
        }

        public async Task DoEdit<T>(T input)
            where T : EditMotorcycleViewModel
        {
            var motorcycle = this.db.Motorcycles.FirstOrDefault(b => b.Id == input.Id);

            if (motorcycle != null)
            {
                motorcycle.Type = input.Type;
                motorcycle.Made = input.Made;
                motorcycle.PriceForHour = input.PriceForHour;
                motorcycle.IsAvailable = input.IsAvailable;
                motorcycle.Description = input.Description;

                await this.db.SaveChangesAsync();
            }
        }

        public T EditDetails<T>(int id)
        {
            return this.db.Motorcycles
           .Where(b => b.Id == id)
           .To<T>()
           .First();
        }

        public IEnumerable<T> GetAllByType<T>(string type, bool isAdministrator)
        {
            MotorcycleType motorcycleType;
            Enum.TryParse<MotorcycleType>(type, out motorcycleType);

            var bicycles = this.db.Motorcycles
                .Where(m => (!isAdministrator ? m.IsAvailable : m.IsAvailable || !m.IsAvailable) && m.Type == motorcycleType)
                .OrderByDescending(m => m.PriceForHour)
                .To<T>()
                .ToArray();

            return bicycles;
        }

        public async Task Delete(int id)
        {
            var motorcycle = this.db.Motorcycles.FirstOrDefault(b => b.Id == id);

            if (motorcycle != null)
            {
                this.imageService.DeleteImage(motorcycle.ImageUrl);

                this.db.Motorcycles.Remove(motorcycle);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var motorcycle = this.db.Motorcycles.FirstOrDefault(b => b.Id == id);

            if (motorcycle != null)
            {
                motorcycle.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(bool isAdministrator)
        {
            var bicycles = this.db.Motorcycles
                .Where(m => !isAdministrator ? m.IsAvailable : m.IsAvailable || !m.IsAvailable)
                .OrderByDescending(m => m.PriceForHour)
                .To<T>()
                .ToArray();

            return bicycles;
        }
    }
}
