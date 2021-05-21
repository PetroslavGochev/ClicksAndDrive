namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum BicycleType
    {
        [Display(Name = "Планински")]
        Mountain = 1,
        [Display(Name = "Шосейни")]
        Road = 2,
        [Display(Name = "Електрически")]
        Electric = 3,
        [Display(Name = "Градски")]
        Trekking = 4,
    }
}
