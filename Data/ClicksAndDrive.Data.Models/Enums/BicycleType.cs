namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum BicycleType
    {
        [Display(Name = "Mountain", ResourceType = typeof(Resourse_BG_))]
        Mountain = 1,
        [Display(Name = "Road", ResourceType = typeof(Resourse_BG_))]
        Road = 2,
        [Display(Name = "Electric", ResourceType = typeof(Resourse_BG_))]
        Electric = 3,
        [Display(Name = "Trekking", ResourceType = typeof(Resourse_BG_))]
        Trekking = 4,
    }
}
