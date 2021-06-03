namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddCarViewModel : IMapTo<Car>
    {
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

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public CarCategory Category { get; set; }

        [Display(Name = "Скоростна кутия")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Разход на гориво")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [Range(1, 1000, ErrorMessage = "Разходът на гориво трябва да е положително число")]
        public double FuelConsumption { get; set; }

        [Display(Name = "Места")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public CarPlaces Places { get; set; }

        [Display(Name = "Цена на час")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [Range(1, 1000, ErrorMessage = "Цената трябва да е положително число")]
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
