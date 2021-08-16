namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ValidateDateRange : ValidationAttribute
    {
        private const string INVALIDDATE = "Моля изберете, правилна дата";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = DateTime.Parse(value.ToString());
            DateTime dateTimeNow = DateTime.Now;

            if (dateTime < dateTimeNow)
            {
                var result = new ValidationResult(INVALIDDATE);
                return result;
            }

            return null;
        }
    }
}
