namespace ClicksAndDrive.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class YearCalculator
    {
        public static byte CalculateYear(DateTime birthday)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - birthday.Year;

            if (birthday > today.AddYears(-age))
            {
                age--;
            }

            return (byte)age;
        }
    }
}
