namespace ClicksAndDrive.Web.ViewModels.Administration.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Data.Models.Enums;

    public class DetailsOrderViewModel
    {
        public int Id { get; set; }

        public string UserEmailAddress { get; set; }

        public string UserPhoneNumber { get; set; }

        public decimal PriceForHour { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public StatusType StatusType { get; set; }

        public string VehicleImageUrl { get; set; }
    }
}
