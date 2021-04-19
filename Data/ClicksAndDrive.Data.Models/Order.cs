using ClicksAndDrive.Data.Models.Enums;
using System;

namespace ClicksAndDrive.Data.Models
{
    public class Order
    {

        public int Id { get; set; }

        public  VehicleType VehicleType{ get; set; }

        public int VehicleId { get; set; }

        public decimal PriceForHour { get; set; }

        public decimal TotalSum { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public bool IsCompleted { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
