namespace ClicksAndDrive.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using ClicksAndDrive.Data;
    using ClicksAndDrive.Data.Models;
    using ClicksAndDrive.Services.Data.Contracts;
    using Microsoft.AspNetCore.Http;

    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext db;

        public ImageService(ApplicationDbContext db)
        {
            this.db = db;
        }

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

        public async Task UploadImages(IList<IFormFile> formImages, int count, string id)
        {
            var imageUrls = new List<string>();

            for (int i = 0; i < formImages.Count; i++)
            {
                var urlName = $"Id{id}_{count + i}";

                var imagePath = string.Format("wwwroot/CardId/{0}.jpg", urlName);

                await this.UploadImage(formImages[i], imagePath);

                var image = new Image()
                {
                    ImageUrl = imagePath,
                    UserId = id,
                };

                await this.db.SaveChangesAsync();
            }
        }
    }
}
