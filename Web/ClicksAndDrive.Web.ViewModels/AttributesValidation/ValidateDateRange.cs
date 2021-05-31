namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ValidateDateRange : RangeAttribute
    {
        public ValidateDateRange()
          : base(
                  typeof(DateTime),
                  DateTime.Now.ToShortDateString(),
                  DateTime.Now.AddMonths(5).ToShortDateString())
        {
        }
    }
}
