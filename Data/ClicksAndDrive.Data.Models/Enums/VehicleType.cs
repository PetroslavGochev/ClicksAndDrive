namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum VehicleType
    {
        [Display(Name = "Car")]
        Car = 1,
        [Display(Name = "Motorcycle")]
        Motorcycle = 2,
        [Display(Name = "Bicycle")]
        Bicycle = 3,
        [Display(Name = "ElectricScooter")]
        ElectricScooter = 4,
    }
}
