namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;
    using Microsoft.AspNetCore.Mvc;

    public class MotorcycleController : Controller
    {
        private const string IMAGE = "Motorcycles";
        private const string ALLPATH = "/Motorcycle/All?type={0}";
        private const string DETAILSPATH = "/Motorcycle/Details/{0}";

        private readonly IMotorcycleService motorcycleService;
        private readonly IImageService imageService;

        public MotorcycleController(IMotorcycleService motorcycleService, IImageService imageService)
        {
            this.motorcycleService = motorcycleService;
            this.imageService = imageService;
        }

        public IActionResult All(string type)
        {
            var isAdministrator = this.User.IsInRole("Administrator");

            var motorcycles = this.motorcycleService.GetAll(type, isAdministrator);

            if (motorcycles.ToArray().Length == 0)
            {
                return this.View("Information");
            }

            return this.View(motorcycles);
        }

        public IActionResult Details(int id)
        {
            var motorcycle = this.motorcycleService.Details(id);

            return this.View(motorcycle);
        }
    }
}
