namespace ClicksAndDrive.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddMotorcycleViewModel : IMapTo<Motorcycle>
    {
        [Required(ErrorMessage = GlobalConstants.Required)]
        public MotorcycleType Type { get; set; }

        [Display(Name = GlobalConstants.Make)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = GlobalConstants.CapitalLetter)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Transsmission)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        public TransmissionType Transmission { get; set; }

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
