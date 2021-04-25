using System.ComponentModel.DataAnnotations;

namespace ClicksAndDrive.Data.Models.Enums
{
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
