using Management.Contracts.Interface;
using Management.DBContext;
using Management.Models;

namespace Management.Services
{
    public class TaskDocumentService : ITaskDocumentService
    {
        private readonly ApplicationDbContext _context;

        public TaskDocumentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UploadFileAsync(IFormFile file, int ActionId, int userId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileModel = new Models.TaskDocument
            {
                FileName = file.FileName,
                Data = memoryStream.ToArray(),
                ActionId = ActionId,
                UploadedBy = userId
             
            };

            _context.TaskDocuments.Add(fileModel);
            await _context.SaveChangesAsync();
        }

        public async Task<TaskDocument> GetFileByIdAsync(int id)
        {
            return await _context.TaskDocuments.FindAsync(id);
        }

        public IEnumerable<dynamic> GetTaskDocumentByUserId(int id)
        {
            List<TaskDocument> docs = _context.TaskDocuments.Where(item => item.UploadedBy == id).ToList();
            return docs.Select(item => new { item.Action, item.ActionId, item.DocumentId, item.FileName}).ToList();
        }
    }
}
