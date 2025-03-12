using FP.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FP.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("save")]
        public IActionResult SaveFile([FromBody] FileRequest request)
        {
            _fileService.SaveFile(request.FileName, request.Content);
            return Ok($"File {request.FileName} saved successfully.");
        }

        [HttpGet("read")]
        public IActionResult ReadFile([FromQuery] string fileName)
        {
            var content = _fileService.ReadFile(fileName);
            return string.IsNullOrEmpty(content)
                ? NotFound($"File {fileName} not found.")
                : Ok(content);
        }
    }

    public class FileRequest
    {
        public string FileName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
