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

        public IEnumerable<CarViewModel> GetAll(string type, bool isAdministrator)
        {
            CarCategory carCategory;
            Enum.TryParse<CarCategory>(type, out carCategory);

            return this.db.Cars
                .Where(c => (!isAdministrator ? c.IsAvailable : c.IsAvailable || !c.IsAvailable) && carCategory == c.Category)
                .Select(c => new CarViewModel()
                {
                    Id = c.Id,
                    Made = c.Made,
                    Model = c.Model,
                    Transmission = c.Transmission,
                    Category = c.Category,
                    Places = c.Places,
                    FuelType = c.FuelType,
                    PriceForHour = c.PriceForHour,
                    ImageUrl = c.ImageUrl,
                })
                .OrderBy(c => c.PriceForHour)
                .ToArray();
        }

        public async Task<int> AddCar(AddCarViewModel input)
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

        public Car Details(int id)
        {
            return this.db.Cars.FirstOrDefault(c => c.Id == id);
        }

        public Car Edit(int id)
        {
            return this.db.Cars.FirstOrDefault(c => c.Id == id);
        }

        public async Task DoEdit(EditCarViewModel input)
        {
            var car = this.db.Cars.FirstOrDefault(b => b.Id == input.Id);

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

        public async Task Delete(int id)
        {
            var car = this.db.Cars.FirstOrDefault(b => b.Id == id);

            if (car != null)
            {
                this.imageSerivce.DeleteImage(car.ImageUrl);

                this.db.Cars.Remove(car);

                await this.db.SaveChangesAsync();
            }
        }

        public async Task AddImageUrls(int id, string imageUrls)
        {
            var car = this.db.Cars.FirstOrDefault(b => b.Id == id);

            if (car != null)
            {
                car.ImageUrl = imageUrls;
                await this.db.SaveChangesAsync();
            }
        }

        public decimal GetPrice(int id)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == id);

            return car.PriceForHour;
        }
    }
}
