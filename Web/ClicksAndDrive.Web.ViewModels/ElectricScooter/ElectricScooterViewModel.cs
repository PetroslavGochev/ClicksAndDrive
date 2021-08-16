namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Mapping;

    public class ElectricScooterViewModel : IMapFrom<ElectricScooter>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        public string ImageUrl { get; set; }
    }
}
