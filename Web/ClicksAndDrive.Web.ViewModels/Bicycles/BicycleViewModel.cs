namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models.Enums;

    public class BicycleViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Resourse_BG_.Made), ResourceType = typeof(Resourse_BG_))]
        public string Made { get; set; }

        [Display(Name = nameof(Resourse_BG_.PriceForHour), ResourceType = typeof(Resourse_BG_))]
        public decimal PriceForHour { get; set; }

        [Display(Name = nameof(Resourse_BG_.Image), ResourceType = typeof(Resourse_BG_))]
        public string ImageUrl { get; set; }

        [Display(Name = nameof(Resourse_BG_.BicycleType), ResourceType = typeof(Resourse_BG_))]
        public BicycleType Type { get; set; }

        [Display(Name = nameof(Resourse_BG_.BicycleSize), ResourceType = typeof(Resourse_BG_))]
        public BicycleSize Size { get; set; }
    }
}
