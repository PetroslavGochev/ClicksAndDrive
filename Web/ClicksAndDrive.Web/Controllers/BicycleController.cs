namespace ClicksAndDrive.Web.Controllers
{
    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class BicycleController : Controller
    {
        private readonly IBicycleService bicycleService;

        public BicycleController(IBicycleService bicycleService)
        {
            this.bicycleService = bicycleService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddBycicleViewModel input)
        {
            if (!input.Image.FileName.EndsWith(".jpg") || input.Image.FileName.EndsWith(".png"))
            {
                this.ModelState.AddModelError("Image", "Invalid type");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect(nameof(this.ThankYou));
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

        public IActionResult Edit(int id)
        {
            var bicycle = this.bicycleService.Edit(id);

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
    }
}
