namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using ClicksAndDrive.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    using System.ComponentModel.DataAnnotations;

    public class AddCarViewModel
    {
        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Model { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public double FuelConsumption { get; set; }

        [Required]
        public CarPlaces Places { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public IFormFile ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}  