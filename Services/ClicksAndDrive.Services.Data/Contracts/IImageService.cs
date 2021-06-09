namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        Task UploadImage(IFormFile formImage, string path);

        Task UploadImages(IList<IFormFile> formImages, int count, string id);

        void DeleteImage(string imagePath);
    }
}
