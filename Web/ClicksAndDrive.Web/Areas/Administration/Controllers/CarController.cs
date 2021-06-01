namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : AdministrationController
    {
        private const string IMAGE = "Cars";
        private const string ALLPATH = "/Car/All?type={0}";
        private const string DETAILSPATH = "/Car/Details/{0}";

        private readonly ICarService carService;
        private readonly IImageService imageService;

        public CarController(ICarService carService, IImageService imageService)
        {
            this.carService = carService;
            this.imageService = imageService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var carId = await this.carService.AddCar(input);

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, carId));

                await this.carService.AddImageUrls(carId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, carId));
            }

            return this.Redirect(string.Format(ALLPATH, input.Category));
        }

        public IActionResult Edit(int id, string type)
        {
            var car = this.carService.Edit(id);

            if (car != null)
            {
                var model = new EditCarViewModel()
                {
                    Id = car.Id,
                    Model = car.Model,
                    Made = car.Made,
                    Transmission = car.Transmission,
                    FuelConsumption = car.FuelConsumption,
                    FuelType = car.FuelType,
                    Category = car.Category,
                    Places = car.Places,
                    IsAvailable = car.IsAvailable,
                    PriceForHour = car.PriceForHour,
                    Description = car.Description,
                };

                return this.View(model);
            }

            return this.Redirect(string.Format(ALLPATH, type));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                await this.carService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            await this.carService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public async Task<IActionResult> Delete(int id, string type)
        {
            await this.carService.Delete(id);

            return this.Redirect(string.Format(ALLPATH, type));
        }
    }
}
