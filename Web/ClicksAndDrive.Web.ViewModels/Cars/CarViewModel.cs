namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System.ComponentModel.DataAnnotations;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class CarViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        [Display(Name = "Марка")]
        public string Made { get; set; }

        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Display(Name = "Категория")]
        public CarCategory Category { get; set; }

        [Display(Name = "Скоростна кутия")]
        public TransmissionType Transmission { get; set; }

        [Display(Name = "Места")]
        public CarPlaces Places { get; set; }

        [Display(Name = "Двигател")]
        public FuelType FuelType { get; set; }

        [Display(Name = "Цена на час")]
        public decimal PriceForHour { get; set; }

        [Display(Name = "Снимка")]
        public string ImageUrl { get; set; }
    }
}
