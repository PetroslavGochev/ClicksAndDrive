namespace ClicksAndDrive.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using ClicksAndDrive.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class ImageService : IImageService
    {
        public async Task UploadImage(IFormFile formImage, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formImage.CopyToAsync(stream);
            }
        }

        public void DeleteImage(string imagePath)
        {
            if (imagePath != null)
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}
