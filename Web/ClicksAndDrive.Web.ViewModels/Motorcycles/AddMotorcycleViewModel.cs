namespace ClicksAndDrive.Web.ViewModels
{
    using ClicksAndDrive.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class AddMotorcycleViewModel
    {
        [Required]
        public MotorcycleType Type { get; set; }

        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }


        [Required]
        public IFormFile ImageUrl { get; set; }


        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
