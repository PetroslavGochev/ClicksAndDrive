namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class EditBicycleViewModel : IMapFrom<Bicycle>, IMapTo<Bicycle>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.Type)]
        public BicycleType Type { get; set; }

        [Display(Name = GlobalConstants.Make)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = GlobalConstants.CapitalLetter)]
        public string Made { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.Speeds)]
        [Range(GlobalConstants.One, GlobalConstants.Thirty, ErrorMessage = GlobalConstants.InvalidSpeeds)]
        public byte Speeds { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.Size)]
        public BicycleSize Size { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.SizeOfTires)]
        [Range(GlobalConstants.Ten, GlobalConstants.Thirty, ErrorMessage = GlobalConstants.InvalidSizeOfTires)]
        public double SizeOfTires { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.IsAvailable)]
        public bool IsAvailable { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        [Required(ErrorMessage = GlobalConstants.Required)]
        [Range(GlobalConstants.One, GlobalConstants.OneHundred, ErrorMessage = GlobalConstants.PositiveNumber)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = GlobalConstants.Description)]
        [StringLength(GlobalConstants.DescriptionLegnth)]
        public string Description { get; set; }
    }
}
