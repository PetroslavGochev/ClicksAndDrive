namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum VehicleType
    {
        [Display(Name = "Car", ResourceType = typeof(Resourse_BG_))]
        Car = 1,
        [Display(Name = "Motorcycle", ResourceType = typeof(Resourse_BG_))]
        Motorcycle = 2,
        [Display(Name = "Bicycle", ResourceType = typeof(Resourse_BG_))]
        Bicycle = 3,
        [Display(Name = "ElectricScooter", ResourceType = typeof(Resourse_BG_))]
        ElectricScooter = 4,
    }
}
