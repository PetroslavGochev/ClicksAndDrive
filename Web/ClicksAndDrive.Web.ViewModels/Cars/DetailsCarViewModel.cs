namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsCarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public string Model { get; set; }

        public FuelType FuelType { get; set; }

        public CarCategory Category { get; set; }

        public TransmissionType Transmission { get; set; }

        public double FuelConsumption { get; set; }

        public CarPlaces Places { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
