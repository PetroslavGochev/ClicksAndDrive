namespace ClicksAndDrive.Web.ViewModels.Motorcycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsMotorcycleViewModel : IMapFrom<Motorcycle>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Type)]
        public MotorcycleType Type { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        public string ImageUrl { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public string Description { get; set; }
    }
}
