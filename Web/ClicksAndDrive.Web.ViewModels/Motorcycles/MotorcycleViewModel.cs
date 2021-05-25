namespace ClicksAndDrive.Web.ViewModels.Motorcycles
{
    using ClicksAndDrive.Data.Models.Enums;

    public class MotorcycleViewModel
    {
        public MotorcycleType Type { get; set; }

        public int Id { get; set; }

        public string Made { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }
    }
}
