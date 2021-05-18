namespace ClicksAndDrive.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IImageService
    {
        void UploadImage(IFormFile formImage, string path);
    }
}
