namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Model)]
        public string Model { get; set; }

        [Display(Name = GlobalConstants.Category)]
        public CarCategory Category { get; set; }

        [Display(Name = GlobalConstants.Transsmission)]
        public TransmissionType Transmission { get; set; }

        [Display(Name = GlobalConstants.Places)]
        public CarPlaces Places { get; set; }

        [Display(Name = GlobalConstants.FuelType)]
        public FuelType FuelType { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        public string ImageUrl { get; set; }
    }
}
