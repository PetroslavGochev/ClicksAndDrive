namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
    {
        private const string IMAGE = "Cars";
        private const string ALLPATH = "/Car/All";
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
        public IActionResult Add(AddCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var carId = this.carService.AddCar(input);

            if (input.ImageTest != null)
            {
                this.imageService.UploadImage(input.ImageTest, string.Format(GlobalConstants.IMAGEPATH, IMAGE, carId));

                this.carService.AddImageUrls(carId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, carId));
            }

            return this.Redirect(ALLPATH);
        }

        public IActionResult Edit(int id)
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

            return this.Redirect(ALLPATH);
        }

        [HttpPost]
        public IActionResult Edit(EditCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                this.carService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            this.carService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public IActionResult All(string type)
        {
            var cars = this.carService.GetAll(type);

            if (cars.ToArray().Length == 0)
            {
                return this.View("Information");
            }

            return this.View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = this.carService.Details(id);

            return this.View(car);
        }

        public IActionResult Delete(int id)
        {
            this.carService.Delete(id);

            return this.Redirect(ALLPATH);
        }
    }
}
