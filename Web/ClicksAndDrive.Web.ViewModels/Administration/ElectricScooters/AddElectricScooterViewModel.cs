﻿namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class AddElectricScooterViewModel
    {
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Марката трябва да започва с главна буква.")]
        public string Made { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Range(1, 50, ErrorMessage = "Скоростта трябва да е в интервал от (1 до 50 км/ч)")]
        public int MaximumSpeed { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Range(1, 1000, ErrorMessage = "Пробега трябва да е положително число")]
        public int Mileage { get; set; }

        [Display(Name = "Цена на час")]
        [Range(1, 1000, ErrorMessage = "Цената трябва да е положително число")]
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