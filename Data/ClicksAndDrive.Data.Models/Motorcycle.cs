namespace ClicksAndDrive.Data.Models
{
    using ClicksAndDrive.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Motorcycle
    {
        public int Id { get; set; }

        public MotorcycleType Type { get; set; }

        [Required]
        public string Made { get; set; }

        public TransmissionType Transmission { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
