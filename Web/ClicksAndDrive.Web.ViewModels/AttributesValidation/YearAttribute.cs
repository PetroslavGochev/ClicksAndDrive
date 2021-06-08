namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class YearAttribute : ValidationAttribute
    {
        private const int MINYEAR = 14;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthdayy = DateTime.Parse(value.ToString());
            DateTime today = DateTime.Today;
            int age = today.Year - birthdayy.Year;
            if (birthdayy > today.AddYears(-age))
            {
                age--;
            }

            if (age < MINYEAR)
            {
                var result = new ValidationResult("Sorry you are not old enough");
                return result;
            }

            return null;
        }
    }
}
