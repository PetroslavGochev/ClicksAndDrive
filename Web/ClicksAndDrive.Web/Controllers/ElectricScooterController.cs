namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricScooterController : Controller
    {
        private readonly IElectricScooterService electricScooterService;

        public ElectricScooterController(IElectricScooterService electricScooterService)
        {
            this.electricScooterService = electricScooterService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddElectricScooterViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public IActionResult All()
        {
            var electricScooters = this.electricScooterService.GetAll();

            return this.View(electricScooters);
        }
    }
}
