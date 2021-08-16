namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddElectricScooterViewModel : IMapTo<ElectricScooter>
    {
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = GlobalConstants.CapitalLetter)]
        public string Made { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(GlobalConstants.One, GlobalConstants.Fifty, ErrorMessage = GlobalConstants.SpeedsLimit)]
        public byte MaximumSpeed { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(GlobalConstants.One, GlobalConstants.OneHundred, ErrorMessage = GlobalConstants.PositiveNumber)]
        public byte Mileage { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        [Range(GlobalConstants.One, GlobalConstants.OneHundred, ErrorMessage = GlobalConstants.PositiveNumber)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = GlobalConstants.Description)]
        [StringLength(GlobalConstants.DescriptionLegnth)]
        public string Description { get; set; }
    }
}
