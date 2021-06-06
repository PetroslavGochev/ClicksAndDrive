namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;

    public class LoanOrderViewModel
    {
        public string VehicleType { get; set; }

        public int VehicleId { get; set; }

        [Required]
        public string Address { get; set; }

        public decimal PriceForHour { get; set; }

        public DateTime DateFrom { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ImageUrl { get; set; }
    }
}
