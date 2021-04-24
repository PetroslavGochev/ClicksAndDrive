namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class AddBycicleViewModel
    {
        [Required]
        public BicycleType Type { get; set; }

        [Required]
        [RegularExpression("[A-Z][^_]+",ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        public byte Speeds { get; set; }

        [Required]
        public BicycleSize Size { get; set; }

        [Required]
        public byte SizeOfTires { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        //[RegularExpression(@"([^\s]+(\.(?i)(jpg|png|gif|bmp))$)", ErrorMessage ="Invalid type")]
        public IFormFile Image { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
