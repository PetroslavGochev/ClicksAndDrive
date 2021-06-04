namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsElectrciScooterViewModel : IMapFrom<Data.Models.ElectricScooter>
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public byte Mileage { get; set; }

        public byte MaximumSpeed { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
