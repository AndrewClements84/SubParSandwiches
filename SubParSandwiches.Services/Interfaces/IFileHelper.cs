using Microsoft.AspNetCore.Http;

namespace SubParSandwiches.Services.Interfaces
{
    public interface IFileHelper
    {
        void DeleteFile(string imageUrl);

        string UploadFile(IFormFile file);
    }
}
