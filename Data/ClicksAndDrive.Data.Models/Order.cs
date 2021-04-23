using ClicksAndDrive.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClicksAndDrive.Data.Models
{
    public class Order
    {

        public int Id { get; set; }

        [Required]
        public  VehicleType VehicleType{ get; set; }

        public int VehicleId { get; set; }

        [Required]
        public decimal PriceForHour { get; set; }

        [Required]
        public decimal TotalSum { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public bool IsCompleted { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
