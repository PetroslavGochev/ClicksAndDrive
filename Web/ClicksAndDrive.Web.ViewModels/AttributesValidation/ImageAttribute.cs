namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System.ComponentModel.DataAnnotations;

    using ClicksAndDrive.Common;
    using Microsoft.AspNetCore.Http;

    public class ImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            IFormFile images = (IFormFile)value;

            if (images.FileName.EndsWith(".jpg"))
            {
                return true;
            }
            else if (images.FileName.EndsWith(".jpeg"))
            {
                return true;
            }
            else if (images.FileName.EndsWith(".png"))
            {
                return true;
            }
            else if (images.FileName.EndsWith(".gif"))
            {
                return true;
            }
            else if (images.Length > 10 * 1024 * 1024)
            {
                this.ErrorMessage = Resourse_BG_.IMAGE_LARGE_FILE;
                return false;
            }

            this.ErrorMessage = Resourse_BG_.IMAGE_WRONG_FILE_NAME;
            return false;
        }
    }
}
