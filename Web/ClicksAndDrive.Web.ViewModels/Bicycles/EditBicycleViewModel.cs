﻿namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class EditBicycleViewModel
    {
        public int Id { get; set; }

        [Required]
        public BicycleType Type { get; set; }

        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        public byte Speeds { get; set; }

        [Required]
        public BicycleSize Size { get; set; }

        [Required]
        public double SizeOfTires { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        public string Image { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
