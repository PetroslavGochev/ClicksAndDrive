﻿namespace ClicksAndDrive.Web.ViewModels.ElectricScooter
{
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Mapping;

    public class ElectricScooterViewModel : IMapFrom<ElectricScooter>
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }
    }
}
