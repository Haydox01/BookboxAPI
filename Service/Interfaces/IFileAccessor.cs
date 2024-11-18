namespace Bookbox.Service
{
    public interface IFileAccessor
    {
        Task<FileUploadResult> UploadFile(IFormFile file);
        Task<string> DeleteFile(string publicId);
    }
}
