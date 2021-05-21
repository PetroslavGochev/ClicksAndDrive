namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum MotorcycleType
    {
        [Display(Name = "Scooter", ResourceType = typeof(Resourse_BG_))]
        Scooter = 1,
        [Display(Name = "Cross", ResourceType = typeof(Resourse_BG_))]
        Cross = 2,
    }
}