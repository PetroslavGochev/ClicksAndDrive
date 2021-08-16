namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddCarViewModel : IMapTo<Car>
    {
        [Display(Name = GlobalConstants.Make)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = GlobalConstants.CapitalLetter)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Model)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = GlobalConstants.CapitalLetter)]
        public string Model { get; set; }

        [Display(Name = GlobalConstants.FuelType)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public FuelType FuelType { get; set; }

        [Display(Name = GlobalConstants.Category)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public CarCategory Category { get; set; }

        [Display(Name = GlobalConstants.Transsmission)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public TransmissionType Transmission { get; set; }

        [Display(Name = GlobalConstants.FuelConsumption)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public double FuelConsumption { get; set; }

        [Display(Name = GlobalConstants.Places)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public CarPlaces Places { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(GlobalConstants.One, GlobalConstants.OneHundred, ErrorMessage = GlobalConstants.PositiveNumber)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = GlobalConstants.Description)]
        [StringLength(GlobalConstants.DescriptionLegnth)]
        public string Description { get; set; }
    }
}
