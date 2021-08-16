namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsElectrciScooterViewModel : IMapFrom<Data.Models.ElectricScooter>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Mileage)]
        public byte Mileage { get; set; }

        [Display(Name = GlobalConstants.MaximumSpeeds)]
        public byte MaximumSpeed { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        public string ImageUrl { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public string Description { get; set; }
    }
}
