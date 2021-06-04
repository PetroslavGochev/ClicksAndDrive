namespace ClicksAndDrive.Web.ViewModels.Motorcycles
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;
    using ClicksAndDrive.Web.ViewModels.AttributesValidation;
    using Microsoft.AspNetCore.Http;

    public class EditMotorcycleViewModel : IMapTo<Motorcycle>, IMapFrom<Motorcycle>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        public MotorcycleType Type { get; set; }

        [Display(Name = "Марка")]
        [Required(ErrorMessage = "Това поле е задължително")]
        [RegularExpression("[A-Z][^_]+", ErrorMessage = "Марката трябва да започва с главна буква.")]
        public string Made { get; set; }

        [Required(ErrorMessage = "Това поле е задължително")]
        public TransmissionType Transmission { get; set; }

        [Required(ErrorMessage = "Това поле е задължително.")]
        [Display(Name = "Наличност")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Цена на час")]
        [Range(1, 1000, ErrorMessage = "Цената трябва да е положително число")]
        [Required(ErrorMessage = "Това поле е задължително")]
        public decimal PriceForHour { get; set; }

        [Display(Name = "Снимка")]
        [ImageAttribute]
        public IFormFile Image { get; set; }

        [Display(Name = "Описание")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}
