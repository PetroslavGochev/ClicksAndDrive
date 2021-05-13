namespace ClicksAndDrive.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum CarPlaces
    {
        [Display(Name = "2+1")]
        One,
        [Display(Name = "5+1")]
        Two,
        [Display(Name = "7+1")]
        Four,
    }
}
