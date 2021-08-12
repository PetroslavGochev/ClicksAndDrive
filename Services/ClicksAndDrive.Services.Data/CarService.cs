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
    using ClicksAndDrive.Web.ViewModels.Cars;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext db;
        private readonly IImageService imageSerivce;

        public CarService(ApplicationDbContext db, IImageService imageService)
        {
            this.db = db;
            this.imageSerivce = imageService;
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == id);

            if (car != null)
            {
                car.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }

        public async Task<int> AddVehicle<T>(T input)
            where T : AddCarViewModel
        {
            var car = new Car()
            {
                Model = input.Model,
                Made = input.Made,
                Transmission = input.Transmission,
                FuelConsumption = input.FuelConsumption,
                FuelType = input.FuelType,
                Category = input.Category,
                Places = input.Places,
                IsAvailable = true,
                PriceForHour = input.PriceForHour,
                Description = input.Description,
            };

            await this.db.Cars.AddAsync(car);

            await this.db.SaveChangesAsync();

            return car.Id;
        }

        public async Task Delete(int id)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == id);

            if (car != null)
            {
                this.imageSerivce.DeleteImage(car.ImageUrl);

                this.db.Cars.Remove(car);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task DoEdit<T>(T input)
            where T : EditCarViewModel
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == input.Id);

            if (car != null)
            {
                car.Model = input.Model;
                car.Made = input.Made;
                car.Transmission = input.Transmission;
                car.FuelConsumption = input.FuelConsumption;
                car.FuelType = input.FuelType;
                car.Category = input.Category;
                car.Places = input.Places;
                car.IsAvailable = input.IsAvailable;
                car.PriceForHour = input.PriceForHour;
                car.Description = input.Description;

                await this.db.SaveChangesAsync();
            }
        }

        public T EditDetails<T>(int id)
        {
            return this.db.Cars
               .Where(b => b.Id == id)
               .To<T>()
               .First();
        }

        public IEnumerable<T> GetAll<T>(bool isAdministrator)
        {
            var cars = this.db.Cars
                .Where(c => !isAdministrator ? c.IsAvailable : c.IsAvailable || !c.IsAvailable)
                .OrderByDescending(c => c.PriceForHour)
                .To<T>()
                .ToArray();

            return cars;
        }

        public IEnumerable<T> GetAllByType<T>(string type, bool isAdministrator)
        {
            CarCategory carCategory;
            Enum.TryParse<CarCategory>(type, out carCategory);

            var cars = this.db.Cars
                .Where(c => (!isAdministrator ? c.IsAvailable : c.IsAvailable || !c.IsAvailable) && c.Category == carCategory)
                .OrderByDescending(c => c.PriceForHour)
                .To<T>()
                .ToArray();

            return cars;
        }
    }
}
