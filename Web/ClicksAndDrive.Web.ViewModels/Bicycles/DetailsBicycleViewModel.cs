namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsBicycleViewModel : IMapFrom<Bicycle>
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public BicycleType Type { get; set; }

        public BicycleSize Size { get; set; }

        public double SizeOfTires { get; set; }

        public byte Speeds { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
