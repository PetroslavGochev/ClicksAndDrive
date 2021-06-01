namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels;
    using ClicksAndDrive.Web.ViewModels.Motorcycles;
    using Microsoft.AspNetCore.Mvc;

    public class MotorcycleController : AdministrationController
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMotorcycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var motorcycleId = await this.motorcycleService.AddMotorcycle(input);

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, motorcycleId));

                await this.motorcycleService.AddImageUrls(motorcycleId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, motorcycleId));
            }

            return this.Redirect(string.Format(ALLPATH, input.Type));
        }

        public IActionResult Edit(int id)
        {
            var bicycle = this.motorcycleService.Edit(id);

            if (bicycle != null)
            {
                var model = new EditMotorcycleViewModel()
                {
                    Id = bicycle.Id,
                    Type = bicycle.Type,
                    Made = bicycle.Made,
                    IsAvailable = bicycle.IsAvailable,
                    PriceForHour = bicycle.PriceForHour,
                    Description = bicycle.Description,
                };

                return this.View(model);
            }

            return this.Redirect(ALLPATH);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMotorcycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                await this.motorcycleService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            await this.motorcycleService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public async Task<IActionResult> Delete(int id, string type)
        {
            await this.motorcycleService.Delete(id);

            return this.Redirect(string.Format(ALLPATH, type));
        }
    }
}
