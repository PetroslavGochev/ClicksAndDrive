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
        private const string IMAGE = "Bicycles";
        private const string ALLPATH = "/Bicycle/All?type={0}";
        private const string DETAILSPATH = "/Bicycle/Details/{0}";

        private readonly IBicycleService bicycleService;
        private readonly IImageService imageService;

        public BicycleController(IBicycleService bicycleService, IImageService imageService)
        {
            this.bicycleService = bicycleService;
            this.imageService = imageService;
        }

        public IActionResult All(string type)
        {
            var isAdministrator = this.User.IsInRole("Administrator");

            var bicycles = this.bicycleService.GetAll(type, isAdministrator);

            if (bicycles.ToArray().Length == 0)
            {
                return this.View("Information");
            }

            return this.View(bicycles);
        }

        public IActionResult Details(int id)
        {
            var bicycle = this.bicycleService.Details(id);

            return this.View(bicycle);
        }
    }
}
