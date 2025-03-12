using FP.Application.Services;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FP.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly string _baseDirectory;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
            _baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "StoredFiles"); // ✅ Guardar en una carpeta específica
            if (!Directory.Exists(_baseDirectory))
            {
                Directory.CreateDirectory(_baseDirectory);
                _logger.LogInformation("Created directory: {BaseDirectory}", _baseDirectory);
            }
        }

        public void SaveFile(string fileName, string content)
        {
            try
            {
                string filePath = Path.Combine(_baseDirectory, fileName);
                File.WriteAllText(filePath, content);
                _logger.LogInformation("File saved: {FilePath}", filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving file: {FileName}", fileName);
            }
        }

        public string ReadFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(_baseDirectory, fileName);
                if (File.Exists(filePath))
                {
                    string content = File.ReadAllText(filePath);
                    _logger.LogInformation("File read: {FilePath}", filePath);
                    return content;
                }
                _logger.LogWarning("File not found: {FilePath}", filePath);
                return string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading file: {FileName}", fileName);
                return string.Empty;
            }
        }
    }
}
