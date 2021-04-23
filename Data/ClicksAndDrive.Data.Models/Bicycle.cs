namespace ClicksAndDrive.Data.Models
{
    using ClicksAndDrive.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Bicycle
    {

        public int Id { get; set; }

        [Required]
        public BicycleType Type { get; set; }

        [Required]
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

        [Required]
        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
