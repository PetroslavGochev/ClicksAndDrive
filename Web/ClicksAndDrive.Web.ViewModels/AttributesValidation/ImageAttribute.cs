namespace ClicksAndDrive.Web.ViewModels.AttributesValidation
{
    using System;
    using System.Collections.Generic;
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

            List<IFormFile> images = new List<IFormFile>();

            images.Add((IFormFile)value);

            foreach (var image in images)
            {
                if (image.Length > 10 * 1024 * 1024)
                {
                    this.ErrorMessage = Resourse_BG_.IMAGE_LARGE_FILE;
                    return false;
                }
                else if (image.FileName.EndsWith(".jpg"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".jpeg"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".png"))
                {
                    continue;
                }
                else if (image.FileName.EndsWith(".gif"))
                {
                    continue;
                }
                else
                {
                    this.ErrorMessage = Resourse_BG_.IMAGE_WRONG_FILE_NAME;
                    return false;
                }
            }

            return true;
        }
    }
}
