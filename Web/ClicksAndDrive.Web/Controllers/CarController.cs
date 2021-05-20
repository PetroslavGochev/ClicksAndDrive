namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
    {
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
                this.imageService.UploadImage(input.ImageTest, string.Format(GlobalConstants.IMAGEPATH, "Cars", carId));

                this.carService.AddImageUrls(carId, string.Format(GlobalConstants.IMAGEPATH, "Cars", carId));
            }

            return this.Redirect(ALLPATH);
        }

        public IActionResult All(string[] category, string[] places, string[] transmissions, string[] fuelType)
        {
            var cars = this.carService.GetAll(category, places, transmissions, fuelType);

            return this.View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = this.carService.Details(id);

            return this.View(car);
        }
    }
}
