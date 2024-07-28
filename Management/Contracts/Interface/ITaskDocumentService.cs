using Management.Models;

namespace Management.Contracts.Interface
{
    public interface ITaskDocumentService
    {
        Task UploadFileAsync(IFormFile file, int ActionId, int userId);
        Task<TaskDocument> GetFileByIdAsync(int id);
        IEnumerable<dynamic> GetTaskDocumentByUserId(int id);

    }
}
