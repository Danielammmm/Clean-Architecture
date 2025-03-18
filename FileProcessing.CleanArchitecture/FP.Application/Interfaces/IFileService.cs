using FP.Application.DTOs;
using FP.Domain.Entities;

namespace FP.Application.Interfaces
{
    public interface IFileService
    {
        Task<List<FileDto>> GetAllFilesAsync();
        Task<bool> AddFileAsync(FileDto fileDto);
        Task<FileRecord?> GetFileByNameAsync(string fileName);
        void SaveFile(string fileName, string content);
        string ReadFile(string fileName);
    }
}
