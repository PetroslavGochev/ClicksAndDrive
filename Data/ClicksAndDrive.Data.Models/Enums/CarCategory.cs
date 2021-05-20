namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;

    public enum CarCategory
    {
        [Display(Name = "Седан")]
        Sedan = 1,
        [Display(Name = "Ван")]
        Van = 2,
        [Display(Name = "Хечбек")]
        HatchBack = 3,
        [Display(Name = "Спорт")]
        Sport = 4,
    }
}
