namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class EditBicycleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.BicycleType), ResourceType = typeof(Resourse_BG_))]
        public BicycleType Type { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.Made), ResourceType = typeof(Resourse_BG_))]
        [RegularExpression("[A-Z][^_]+", ErrorMessageResourceName = nameof(Resourse_BG_.MADE_UPPER_LETTER), ErrorMessageResourceType = typeof(Resourse_BG_))]
        public string Made { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.Speeds), ResourceType = typeof(Resourse_BG_))]
        [Range(1, 30, ErrorMessageResourceName = nameof(Resourse_BG_.SPEEDS_RANGE), ErrorMessageResourceType = typeof(Resourse_BG_))]
        public byte Speeds { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.BicycleSize), ResourceType = typeof(Resourse_BG_))]
        public BicycleSize Size { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.SizeOfTires), ResourceType = typeof(Resourse_BG_))]
        [Range(10, 30, ErrorMessageResourceName = nameof(Resourse_BG_.SizeOfTires), ErrorMessageResourceType = typeof(Resourse_BG_))]
        public double SizeOfTires { get; set; }

        [Required(ErrorMessage = "Това поле е задължително.")]
        [Display(Name = "Наличност")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resourse_BG_.REQUIRED), ErrorMessageResourceType = typeof(Resourse_BG_))]
        [Display(Name = nameof(Resourse_BG_.PriceForHour), ResourceType = typeof(Resourse_BG_))]
        [Range(0, 100, ErrorMessageResourceName = nameof(Resourse_BG_.PRICE), ErrorMessageResourceType = typeof(Resourse_BG_))]
        public decimal PriceForHour { get; set; }

        [ImageAttribute]
        [Display(Name = nameof(Resourse_BG_.Image), ResourceType = typeof(Resourse_BG_))]
        public IFormFile Image { get; set; }

        [Display(Name = nameof(Resourse_BG_.Description), ResourceType = typeof(Resourse_BG_))]
        [StringLength(250, ErrorMessageResourceName = nameof(Resourse_BG_.DESCRIPTION_LENGHT), ErrorMessageResourceType = typeof(Resourse_BG_))]
        public string Description { get; set; }
    }
}
