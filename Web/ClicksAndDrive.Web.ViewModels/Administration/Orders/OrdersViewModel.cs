namespace ClicksAndDrive.Web.ViewModels.Administration.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ClicksAndDrive.Data.Models.Enums;

    public class OrdersViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public StatusType StatusType { get; set; }
    }
}
