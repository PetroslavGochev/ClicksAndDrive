namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsCarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Model { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public FuelType FuelType { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public CarCategory Category { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public TransmissionType Transmission { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public double FuelConsumption { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public CarPlaces Places { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string ImageUrl { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Description { get; set; }
    }
}
