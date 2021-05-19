namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum CarCategory
    {
        [Display(Name = "Sedan", ResourceType = typeof(Resourse_BG_))]
        Sedan = 1,
        [Display(Name = "Van", ResourceType = typeof(Resourse_BG_))]
        Van = 2,
        [Display(Name = "HatchBack", ResourceType = typeof(Resourse_BG_))]
        HatchBack = 3,
        [Display(Name = "Sport", ResourceType = typeof(Resourse_BG_))]
        Sport = 4,
    }
}
