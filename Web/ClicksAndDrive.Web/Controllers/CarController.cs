﻿namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
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

        public IActionResult All(string type)
        {
            var isAdministrator = this.User.IsInRole("Administrator");

            var cars =
                type != null
                ? this.carService.GetAllByType<CarViewModel>(type, isAdministrator)
                : this.carService.GetAll<CarViewModel>(isAdministrator);

            if (cars.ToArray().Length == 0)
            {
                return this.View("Information");
            }

            return this.View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = this.carService.EditDetails<DetailsCarViewModel>(id);

            return this.View(car);
        }
    }
}
