namespace ClicksAndDrive.Web.Controllers
{
    using System.Linq;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.AspNetCore.Mvc;

    public class BicycleController : Controller
    {
        private const string IMAGE = "Bicycles";
        private const string ALLPATH = "/Bicycle/All";
        private const string DETAILSPATH = "/Bicycle/Details/{0}";

        private readonly IBicycleService bicycleService;
        private readonly IImageService imageService;

        public BicycleController(IBicycleService bicycleService, IImageService imageService)
        {
            this.bicycleService = bicycleService;
            this.imageService = imageService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddBycicleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var bicycleId = this.bicycleService.AddBicycle(input);

            if (input.Image != null)
            {
                this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, bicycleId));

                this.bicycleService.AddImageUrls(bicycleId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, bicycleId));
            }

            return this.Redirect(string.Format(DETAILSPATH,bicycleId));
        }


        public IActionResult All(string type)
        {
            var bicycles = this.bicycleService.GetAll(type);

            if (bicycles.ToArray().Length == 0)
            {
                return this.NotFound();
            }

            return this.View(bicycles);
        }

        public IActionResult Details(int id)
        {
            var bicycle = this.bicycleService.Details(id);

            return this.View(bicycle);
        }

        public IActionResult Edit(int id)
        {
            var bicycle = this.bicycleService.Edit(id);

            if (bicycle != null)
            {
                var model = new EditBicycleViewModel()
                {
                    Id = bicycle.Id,
                    Type = bicycle.Type,
                    Made = bicycle.Made,
                    Speeds = bicycle.Speeds,
                    Size = bicycle.Size,
                    IsAvailable = bicycle.IsAvailable,
                    SizeOfTires = bicycle.SizeOfTires,
                    PriceForHour = bicycle.PriceForHour,
                    Description = bicycle.Description,
                };

                return this.View(model);
            }

            return this.Redirect(ALLPATH);
        }

        [HttpPost]
        public IActionResult Edit(EditBicycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                this.bicycleService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            this.bicycleService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public IActionResult Delete(int id)
        {
            this.bicycleService.Delete(id);

            return this.Redirect(ALLPATH);
        }
    }
}
