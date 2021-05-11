namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricScooterController : Controller
    {
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
    }
}
