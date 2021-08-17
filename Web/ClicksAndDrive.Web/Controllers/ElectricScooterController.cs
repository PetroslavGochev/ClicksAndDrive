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
        private readonly IElectricScooterService elecitrcScooterService;
        private readonly IImageService imageService;

        public ElectricScooterController(IElectricScooterService elecitrcScooterService, IImageService imageService)
        {
            this.elecitrcScooterService = elecitrcScooterService;
            this.imageService = imageService;
        }

        public IActionResult All()
        {
            var isAdministrator = this.User.IsInRole(GlobalConstants.ADMINISTRATOR);

            var electrcicScooter = this.elecitrcScooterService.GetAllByType<ElectricScooterViewModel>(null, isAdministrator);

            if (electrcicScooter.ToArray().Length == 0)
            {
                return this.View(GlobalConstants.INFORMATION);
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
