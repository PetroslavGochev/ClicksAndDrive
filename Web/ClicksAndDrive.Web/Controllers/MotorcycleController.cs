namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;

    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;
    using Microsoft.AspNetCore.Mvc;

    public class MotorcycleController : Controller
    {
        private readonly IMotorcycleService motorcycleService;
        private readonly IImageService imageService;

        public MotorcycleController(IMotorcycleService motorcycleService, IImageService imageService)
        {
            this.motorcycleService = motorcycleService;
            this.imageService = imageService;
        }

        public IActionResult All(string type)
        {
            var isAdministrator = this.User.IsInRole(GlobalConstants.ADMINISTRATOR);

            var motorcycles =
                type != null
                ? this.motorcycleService.GetAllByType<MotorcycleViewModel>(type, isAdministrator)
                : this.motorcycleService.GetAll<MotorcycleViewModel>(isAdministrator);

            if (motorcycles.ToArray().Length == 0)
            {
                return this.View(GlobalConstants.INFORMATION);
            }

            return this.View(motorcycles);
        }

        public IActionResult Details(int id)
        {
            var motorcycle = this.motorcycleService.EditDetails<DetailsMotorcycleViewModel>(id);

            return this.View(motorcycle);
        }
    }
}
