namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BicycleController : Controller
    {
        private readonly IBicycleService bicycleService;
        private readonly IImageService imageService;

        public BicycleController(IBicycleService bicycleService, IImageService imageService)
        {
            this.bicycleService = bicycleService;
            this.imageService = imageService;
        }

        public IActionResult All(string type)
        {
            var isAdministrator = this.User.IsInRole(GlobalConstants.ADMINISTRATOR);

            var bicycles =
                type != null
                ? this.bicycleService.GetAllByType<BicycleViewModel>(type, isAdministrator)
                : this.bicycleService.GetAll<BicycleViewModel>(isAdministrator);

            if (bicycles.ToArray().Length == 0)
            {
                return this.View(GlobalConstants.INFORMATION);
            }

            return this.View(bicycles);
        }

        public IActionResult Details(int id)
        {
            var bicycle = this.bicycleService.EditDetails<DetailsBicycleViewModel>(id);

            return this.View(bicycle);
        }
    }
}
