﻿namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class EditBicycleViewModel : IMapFrom<Bicycle>, IMapTo<Bicycle>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Display(Name = "Категория")]
        public BicycleType Type { get; set; }

        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Марката трябва да започва с главна буква.")]
        public string Made { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Display(Name = "Скорости")]
        [Range(1, 30, ErrorMessage = "Скоростите трябва да са в интервал от (0 - 30)")]
        public byte Speeds { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Display(Name = "Размер на велосипеда")]
        public BicycleSize Size { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        [Display(Name = "Размер на гумите")]
        [Range(10, 30, ErrorMessage = "Размерът на гумите трябва да е число в интервала (10 - 30)")]
        public double SizeOfTires { get; set; }

        [Required(ErrorMessage = "Това поле е задължително.")]
        [Display(Name = "Наличност")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Цена на час")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [Range(1, 1000, ErrorMessage = "Цената трябва да е положително число")]
        public decimal PriceForHour { get; set; }

        [Display(Name = "Снимка")]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = "Описание")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}