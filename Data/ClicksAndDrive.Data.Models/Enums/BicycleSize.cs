namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum BicycleSize
    {
        [Display(Name = "XS",ResourceType = typeof(Resourse_BG_))]
        XS = 1,
        [Display(Name = "S", ResourceType = typeof(Resourse_BG_))]
        S = 2,
        [Display(Name = "M", ResourceType = typeof(Resourse_BG_))]
        M = 3,
        [Display(Name = "L", ResourceType = typeof(Resourse_BG_))]
        L = 4,
        [Display(Name = "XL", ResourceType = typeof(Resourse_BG_))]
        XL = 5,
    }
}
