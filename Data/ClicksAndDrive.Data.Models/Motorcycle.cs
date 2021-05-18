namespace ClicksAndDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;

    public class Motorcycle
    {
        public int Id { get; set; }

        [Required]
        public MotorcycleType Type { get; set; }

        [Required]
        public string Made { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
