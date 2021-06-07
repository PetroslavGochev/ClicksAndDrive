namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ValidateDateRange : ValidationAttribute
    {
        public ValidateDateRange()
            : base("Date should be less than current date")
        {
        }

        public override bool IsValid(object value)
        {
            DateTime propValue = Convert.ToDateTime(value);

            if (propValue <= DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
