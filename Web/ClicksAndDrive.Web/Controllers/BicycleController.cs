namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
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
                this.imageService.UploadImage(input.Image, string.Format("wwwroot/images/Bicycles/image{0}.jpg", bicycleId));

                this.bicycleService.AddImageUrls(bicycleId, string.Format("wwwroot/images/Bicycles/image{0}.jpg", bicycleId));
            }

            this.Redirect(nameof(this.ThankYou));
            return this.Redirect("/Bicycle/All");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

        public IActionResult All(string[] size, string[] type)
        {
            var bicycles = this.bicycleService.GetAll(size, type);

            return this.View(bicycles);
        }

        public IActionResult Details(int id)
        {
            var bicycle = this.bicycleService.Details(id);

            return this.View(bicycle);
        }

        public IActionResult Edit(int id, string confirm)
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
                    SizeOfTires = bicycle.SizeOfTires,
                    PriceForHour = bicycle.PriceForHour,
                    Description = bicycle.Description,
                };

                return this.View(model);
            }

            return this.Redirect($"/Bicycle/All");
        }

        [HttpPost]
        public IActionResult Edit(EditBicycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            this.bicycleService.DoEdit(input);

            return this.Redirect($"/Bicycle/Details/{input.Id}");
        }

        public IActionResult Delete(int id)
        {
            this.bicycleService.Delete(id);

            return this.Redirect($"/Bicycle/All");
        }
    }
}
