namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum TransmissionType
    {
        [Display(Name = "Ръчна")]
        Manual = 1,
        [Display(Name = "Автоматична")]
        Automatic = 2,
    }
}
