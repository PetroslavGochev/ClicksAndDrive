namespace ClicksAndDrive.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddMotorcycleViewModel
    {
        [Required(ErrorMessage = "Това поле е задължително")]
        public MotorcycleType Type { get; set; }

        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Марката трябва да започва с главна буква.")]
        public string Made { get; set; }

        [Display(Name = "Скоростна кутия")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Цена на час")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public decimal PriceForHour { get; set; }

        [Display(Name = "Снимка")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = "Описание")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
