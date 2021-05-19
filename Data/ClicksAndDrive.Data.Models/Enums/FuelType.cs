namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum FuelType
    {
        [Display(Name = "Diesel", ResourceType = typeof(Resourse_BG_))]
        Diesel = 1,
        [Display(Name = "Gasoline", ResourceType = typeof(Resourse_BG_))]
        Gasoline = 2,
        [Display(Name = "Gas", ResourceType = typeof(Resourse_BG_))]
        Gas = 3,
        [Display(Name = "Electric", ResourceType = typeof(Resourse_BG_))]
        Electric = 4,
    }
}
