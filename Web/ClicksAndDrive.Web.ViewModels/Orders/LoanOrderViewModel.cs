namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;

    public class LoanOrderViewModel
    {
        private const string DATETIMEFORMAT = "MM/dd/yyyy HH:mm";

        public string VehicleType { get; set; }

        public int VehicleId { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.Address)]
        public string Address { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = DATETIMEFORMAT)]
        [Display(Name = GlobalConstants.DateTo)]
        [ValidateDateRange]
        public DateTime DateFrom { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public string UserName { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        [Display(Name = GlobalConstants.Email)]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.Required)]
        public string ImageUrl { get; set; }
    }
}
