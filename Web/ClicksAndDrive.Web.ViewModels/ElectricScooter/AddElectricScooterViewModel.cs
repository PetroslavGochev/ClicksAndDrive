namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class AddElectricScooterViewModel
    {
        [Required]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Name should start with upper letter.")]
        public string Made { get; set; }

        [Required]
        [Range(5,35)] 
        public int MaximumSpeed { get; set; }

        [Required]
        public int Mileage { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public IFormFile ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}