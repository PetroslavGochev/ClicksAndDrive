namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricScooterController : Controller
    {
        private const string IMAGE = "ElectricScooters";
        private const string ALLPATH = "/ElectricScooter/All";
        private const string DETAILSPATH = "/ElectricScooter/Details/{0}";

        private readonly IElectricScooterService elecitrcScooterService;
        private readonly IImageService imageService;

        public ElectricScooterController(IElectricScooterService elecitrcScooterService, IImageService imageService)
        {
            this.elecitrcScooterService = elecitrcScooterService;
            this.imageService = imageService;
        }

        public IActionResult All()
        {
            var isAdministrator = this.User.IsInRole("Administrator");

            var electrcicScooter = this.elecitrcScooterService.GetAll<ElectricScooterViewModel>(null, isAdministrator);

            if (electrcicScooter.ToArray().Length == 0)
            {
                return this.View("Information");
            }

            return this.View(electrcicScooter);
        }

        public IActionResult Details(int id)
        {
            var electrciScooter = this.elecitrcScooterService.EditDetails<DetailsElectrciScooterViewModel>(id);

            return this.View(electrciScooter);
        }
    }
}
