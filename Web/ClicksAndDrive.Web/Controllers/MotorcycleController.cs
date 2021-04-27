namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Web.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class MotorcycleController : Controller
    {
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
    }
}
