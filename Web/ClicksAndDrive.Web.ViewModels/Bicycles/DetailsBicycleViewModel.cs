namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ClicksAndDrive.Common;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;
    using ClicksAndDrive.Services.Mapping;

    public class DetailsBicycleViewModel : IMapFrom<Bicycle>
    {
        public int Id { get; set; }

        [Display(Name = GlobalConstants.Make)]
        public string Made { get; set; }

        [Display(Name = GlobalConstants.Type)]
        public BicycleType Type { get; set; }

        [Display(Name = GlobalConstants.Size)]
        public BicycleSize Size { get; set; }

        [Display(Name = GlobalConstants.SizeOfTires)]
        public double SizeOfTires { get; set; }

        [Display(Name = GlobalConstants.Speeds)]
        public byte Speeds { get; set; }

        [Display(Name = GlobalConstants.PriceForHour)]
        public decimal PriceForHour { get; set; }

        [Display(Name = GlobalConstants.Images)]
        public string ImageUrl { get; set; }

        [Display(Name = GlobalConstants.Description)]
        public string Description { get; set; }
    }
}
