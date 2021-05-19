namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum TransmissionType
    {
        [Display(Name = "Manual", ResourceType = typeof(Resourse_BG_))]
        Manual = 1,
        [Display(Name = "Automatic", ResourceType = typeof(Resourse_BG_))]
        Automatic = 2,
    }
}
