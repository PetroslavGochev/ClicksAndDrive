namespace ClicksAndDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ElectricScooter
    {
        public int Id { get; set; }

        [Required]
        public string  Make { get; set; }

        public int MaximumSpeed { get; set; }

        [Required]
        public int Mileage { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
