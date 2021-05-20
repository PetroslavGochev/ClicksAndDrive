﻿namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Web.ViewModels.Cars;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext db;

        public CarService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCar(AddCarViewModel input)
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

            this.db.Cars.Add(car);

            this.db.SaveChanges();

            return car.Id;
        }

        public void AddImageUrls(int id, string imageUrls)
        {
            var car = this.db.Cars.FirstOrDefault(b => b.Id == id);

            if (car != null)
            {
                car.ImageUrl = imageUrls;
                this.db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Car Details(int id)
        {
            return this.db.Cars.FirstOrDefault(c => c.Id == id);
        }

        public void DoEdit(EditCarViewModel input)
        {
            throw new System.NotImplementedException();
        }

        public Car Edit(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CarViewModel> GetAll(string[] category, string[] places, string[] transmissions, string[] fuelType)
        {
            return this.db.Cars
                .Where(c => c.IsAvailable)
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
                    Filters = category.Length == 0 &&
                                places.Length == 0 &&
                                transmissions.Length == 0 &&
                                fuelType.Length == 0 ? null : new FilterCarViewModel()
                    {
                        Category = category,
                        Places = places,
                        Transmission = transmissions,
                        FuelType = fuelType,
                    },
                })
                .ToArray();
        }
    }
}
