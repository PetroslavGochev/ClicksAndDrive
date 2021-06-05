namespace ClicksAndDrive.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        public int VehicleId { get; set; }

        public string Address { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public decimal TotalSum { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public StatusType Status { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
