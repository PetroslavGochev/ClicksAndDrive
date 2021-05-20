namespace ClicksAndDrive.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FilterCarViewModel
    {
        public string[] Category { get; set; }

        public string[] Transmission { get; set; }

        public string[] Places { get; set; }

        public string[] FuelType { get; set; }
    }
}
