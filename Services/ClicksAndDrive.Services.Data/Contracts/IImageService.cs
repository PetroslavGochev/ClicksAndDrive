namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        Task UploadImage(IFormFile formImage, string path);

        void DeleteImage(string imagePath);
    }
}
