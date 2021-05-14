namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
    {
        private ICarService carService;

        public CarController(ICarService carService)
        {
            this.carService = carService;
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

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            var cars = this.carService.GetAll();

            return this.View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = this.carService.Details(id);

            return this.View(car);
        }
    }
}
