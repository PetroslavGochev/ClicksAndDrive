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

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "MM/dd/yyyy HH:mm")]
        [ValidateDateRange]
        public DateTime DateFrom { get; set; }

        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
