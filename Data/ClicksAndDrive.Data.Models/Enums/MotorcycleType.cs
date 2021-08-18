namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum MotorcycleType
    {
        [Display(Name = "Скутер")]
        Scooter = 1,
        [Display(Name = "Кросов")]
        Cross = 2,
    }
}