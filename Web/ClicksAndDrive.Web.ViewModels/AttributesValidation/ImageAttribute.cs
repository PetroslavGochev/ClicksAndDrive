using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    public class ImageAttribute : ValidationAttribute 
    {
        public override bool IsValid(object value)
        {
            IFormFile images = (IFormFile)value;
            bool result = true;
            if (!images.FileName.EndsWith(".jpg"))
            {
                result = false;
            }
            else if(images.Length > 10 * 1024 * 1024)
            {
                result = false;
            }
            return result;
        }
    }
}
