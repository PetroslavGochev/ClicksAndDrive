namespace ClicksAndDrive.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class AddMotorcycleViewModel
    {
        [Required]
        public MotorcycleType Type { get; set; }

        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public IFormFile ImageUrl { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
