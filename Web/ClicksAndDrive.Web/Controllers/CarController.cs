namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : Controller
    {
        public IActionResult Add()
        {
            return this.View();
        }

        public IActionResult Add(AddCarViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            return this.Redirect("/");
        }
    }
}
