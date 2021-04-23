namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.AspNetCore.Mvc;


    public class BicycleController : Controller
    {
        public IActionResult Add()
        {         
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddBycicleViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            return this.Redirect(nameof(ThankYou));
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
