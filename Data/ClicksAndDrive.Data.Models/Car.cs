namespace ClicksAndDrive.Data.Models
{
    using ClicksAndDrive.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {

        public int Id { get; set; }

        [Required]
        public string  Made { get; set; }

        [Required]
        public string  Model { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        public double FuelConsumption { get; set; }

        public string Places { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
