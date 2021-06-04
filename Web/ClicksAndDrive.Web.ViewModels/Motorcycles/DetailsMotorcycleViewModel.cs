namespace ClicksAndDrive.Web.ViewModels.Motorcycles
{
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsMotorcycleViewModel : IMapFrom<Motorcycle>
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public MotorcycleType Type { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
