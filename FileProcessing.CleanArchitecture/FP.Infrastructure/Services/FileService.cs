using FP.Application.Services;
using FP.Infrastructure.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FP.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly FileManager _fileManager;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "StoredFiles");
            _fileManager = new FileManager(baseDirectory);
        }

        //  Etapa 1: Función inexistente (Prueba fallida)
        /*
        public void SaveFile(string fileName, string content)
        {
            // Método no implementado (provocará error en la prueba)
        }

        public string ReadFile(string fileName)
        {
            // Método no implementado (provocará error en la prueba)
        }
        */

        // 🟡 Etapa 2: Implementación mínima (Prueba pasa, pero código sin optimizar)
        /*
        public void SaveFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content);  // No maneja excepciones ni directorio base
        }

        public string ReadFile(string fileName)
        {
            return File.Exists(fileName) ? File.ReadAllText(fileName) : string.Empty; // ⚠️ No maneja logs
        }
        */

        // Etapa 3: Implementación optimizada (Versión final mejorada)
        public void SaveFile(string fileName, string content)
        {
            try
            {
                _fileManager.WriteToFile(fileName, content);
                _logger.LogInformation("File saved: {FileName}", fileName);
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
                string content = _fileManager.ReadFromFile(fileName);
                _logger.LogInformation("File read: {FileName}", fileName);
                return content;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading file: {FileName}", fileName);
                return string.Empty;
            }
        }
    }
}
