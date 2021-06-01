namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data;
    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.Bicycles;
    using Microsoft.AspNetCore.Mvc;

    public class BicycleController : AdministrationController
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBycicleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var bicycleId = await this.bicycleService.AddBicycle(input);

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, bicycleId));

                await this.bicycleService.AddImageUrls(bicycleId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, bicycleId));
            }

            return this.Redirect(string.Format(ALLPATH, input.Type));
        }

        public IActionResult Edit(int id, string type)
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

            return this.Redirect(string.Format(ALLPATH, type));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBicycleViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                await this.bicycleService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            await this.bicycleService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public async Task<IActionResult> Delete(int id, string type)
        {
            await this.bicycleService.Delete(id);

            return this.Redirect(string.Format(ALLPATH, type));
        }
    }
}
