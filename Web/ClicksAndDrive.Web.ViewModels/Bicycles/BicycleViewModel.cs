namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using ClicksAndDrive.Data.Models.Enums;

    public class BicycleViewModel
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        public BicycleType Type { get; set; }

        public BicycleSize Size { get; set; }

        public FilterBicycleViewModel Filters { get; set; }
    }
}
