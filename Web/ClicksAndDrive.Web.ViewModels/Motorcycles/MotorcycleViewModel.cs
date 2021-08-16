namespace ClicksAndDrive.Web.ViewModels.Motorcycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class MotorcycleViewModel : IMapFrom<Motorcycle>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public MotorcycleType Type { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public string ImageUrl { get; set; }
    }
}
