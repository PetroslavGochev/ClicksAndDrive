namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class MotorcycleController : Controller
    {
        private readonly IMotorcycleService motorcycleService;

        public MotorcycleController(IMotorcycleService motorcycleService)
        {
            this.motorcycleService = motorcycleService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddMotorcycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            var motorcycles = this.motorcycleService.GetAll();

            return this.View(motorcycles);
        }

        public IActionResult Details(int id)
        {
            var motorcycle = this.motorcycleService.Details(id);

            return this.View(motorcycle);
        }
    }
}
