namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum BicycleSize
    {
        [Display(Name = "XS")]
        XS = 1,
        [Display(Name = "S")]
        S = 2,
        [Display(Name = "M")]
        M = 3,
        [Display(Name = "L")]
        L = 4,
        [Display(Name = "XL")]
        XL = 5,
    }
}
