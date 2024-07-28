using Management.Contracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly ITaskDocumentService _fileService;

        public FilesController(ITaskDocumentService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, int actionId, int userId)
        {
            try
            {
                await _fileService.UploadFileAsync(file,actionId,userId);
                return Ok(new { message = "File uploaded successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            return File(file.Data, "application/octet-stream", file.FileName);
        }

        [HttpGet("/ByUser/{id}")]
        public async Task<IActionResult> GetUploadedFilesByUser(int userId)
        {
            var docs = _fileService.GetTaskDocumentByUserId(userId);
            return Ok(docs);
        }
    }

}
