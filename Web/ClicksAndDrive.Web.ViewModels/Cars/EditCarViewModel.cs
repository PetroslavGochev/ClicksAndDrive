namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class EditCarViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Марката трябва да започва с главна буква.")]
        public string Made { get; set; }

        [Display(Name = "Модел")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Моделът трябва да започва с главна буква.")]
        public string Model { get; set; }

        [Display(Name = "Двигател")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Категоия")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public CarCategory Category { get; set; }

        [Display(Name = "Скоростна кутия")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Разход на гориво")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public double FuelConsumption { get; set; }

        [Display(Name = "Места")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public CarPlaces Places { get; set; }

        [Required(ErrorMessage = "Това поле е задължително.")]
        [Display(Name = "Наличност")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Цена на час")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public decimal PriceForHour { get; set; }

        [Display(Name = "Снимка")]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = "Описание")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
