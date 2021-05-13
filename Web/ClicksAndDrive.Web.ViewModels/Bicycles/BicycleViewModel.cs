namespace ClicksAndDrive.Web.ViewModels.Bicycles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BicycleViewModel
    {
        public int Id { get; set; }

        public string Made { get; set; }

        public decimal PriceForHour { get; set; }

        public string ImageUrl { get; set; }
    }
}
