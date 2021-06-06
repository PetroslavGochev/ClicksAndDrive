namespace ClicksAndDrive.Web.ViewModels.Orders
{
    using ClicksAndDrive.Data.Models.Enums;

    public class VehicleDataViewModel
    {
        public int VehicleId { get; set; }

        public VehicleType Type { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }
    }
}
