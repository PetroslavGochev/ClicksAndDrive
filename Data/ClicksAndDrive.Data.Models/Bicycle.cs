namespace ClicksAndDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;

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
        public double SizeOfTires { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
