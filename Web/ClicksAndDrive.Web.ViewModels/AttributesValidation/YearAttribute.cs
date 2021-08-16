namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ClicksAndDrive.Common;

    public class YearAttribute : ValidationAttribute
    {
        private const int MINYEAR = 14;
        private const string YEARSOLD = "Нямате навършени 14 години.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime birthdayy = DateTime.Parse(value.ToString());

            int age = YearCalculator.CalculateYear(birthdayy);

            if (age < MINYEAR)
            {
                var result = new ValidationResult(YEARSOLD);
                return result;
            }

            return null;
        }
    }
}
