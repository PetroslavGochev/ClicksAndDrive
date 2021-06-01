namespace ClicksAndDrive.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data.Contracts;
    using ClicksAndDrive.Web.Common;
    using ClicksAndDrive.Web.ViewModels.ElectricScooter;
    using Microsoft.AspNetCore.Mvc;

    public class ElectricScooterController : AdministrationController
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

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddElectricScooterViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var electricScooterId = await this.elecitrcScooterService.AddElectricScooter(input);

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, electricScooterId));

                await this.elecitrcScooterService.AddImageUrls(electricScooterId, string.Format(GlobalConstants.IMAGEPATH, IMAGE, electricScooterId));
            }

            return this.Redirect(ALLPATH);
        }

        public IActionResult Edit(int id)
        {
            var electrciScooter = this.elecitrcScooterService.Edit(id);

            if (electrciScooter != null)
            {
                var model = new EditElectricScooterViewModel()
                {
                    Id = electrciScooter.Id,
                    Made = electrciScooter.Made,
                    MaximumSpeed = electrciScooter.MaximumSpeed,
                    Mileage = electrciScooter.Mileage,
                    IsAvailable = electrciScooter.IsAvailable,
                    PriceForHour = electrciScooter.PriceForHour,
                    Description = electrciScooter.Description,
                };

                return this.View(model);
            }

            return this.Redirect(ALLPATH);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditElectricScooterViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (input.Image != null)
            {
                await this.imageService.UploadImage(input.Image, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));

                await this.elecitrcScooterService.AddImageUrls(input.Id, string.Format(GlobalConstants.IMAGEPATH, IMAGE, input.Id));
            }

            await this.elecitrcScooterService.DoEdit(input);

            return this.Redirect(string.Format(DETAILSPATH, input.Id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.elecitrcScooterService.Delete(id);

            return this.Redirect(ALLPATH);
        }
    }
}
