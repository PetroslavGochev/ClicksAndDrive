namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum FuelType
    {
        [Display(Name = "Дизел")]
        Diesel = 1,
        [Display(Name = "Бензин")]
        Gasoline = 2,
        [Display(Name = "Газ")]
        Gas = 3,
        [Display(Name = "Електрически")]
        Electric = 4,
    }
}
