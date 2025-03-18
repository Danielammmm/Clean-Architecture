using FP.Application.DTOs;
using FP.Application.Interfaces;
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
        public async Task<IActionResult> SaveFile([FromBody] FileDto fileDto)
        {
            if (fileDto == null || string.IsNullOrEmpty(fileDto.FileName))
            {
                return BadRequest("Invalid file data.");
            }

            bool isSaved = await _fileService.AddFileAsync(fileDto);

            if (!isSaved)
            {
                return Conflict($"El archivo {fileDto.FileName} ya existe.");
            }

            return Ok($"File {fileDto.FileName} saved successfully.");
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileService.GetAllFilesAsync();
            return Ok(files);
        }


        [HttpGet("search")]
        public async Task<IActionResult> GetFileByName([FromQuery] string fileName)
        {
            var file = await _fileService.GetFileByNameAsync(fileName);

            if (file == null)
            {
                return NotFound($"Archivo {fileName} no encontrado.");
            }

            return Ok(file);
        }



    }
}
