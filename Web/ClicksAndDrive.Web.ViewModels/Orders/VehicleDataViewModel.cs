namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models.Enums;

    public class VehicleDataViewModel
    {
        public int VehicleId { get; set; }

        [Display(Name = GlobalConstants.Type)]
        public VehicleType Type { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }
    }
}
