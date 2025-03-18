using FP.Application.Interfaces;
using FP.Application.DTOs;
using FP.Infrastructure.Persistence;
using FP.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FP.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace FP.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly FileManager _fileManager;
        private readonly AppDbContext _context;

        public FileService(ILogger<FileService> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "StoredFiles");
            _fileManager = new FileManager(baseDirectory);
        }

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

        public async Task<List<FileDto>> GetAllFilesAsync()
        {
            var files = await _context.Files
                .FromSqlRaw("EXEC GetAllFiles")
                .ToListAsync();

            return files.Select(f => new FileDto
            {
                FileName = f.FileName,
                FilePath = f.FilePath
            }).ToList();
        }


        public async Task<bool> AddFileAsync(FileDto fileDto)
        {
            var parameters = new[]
            {
        new SqlParameter("@FileName", fileDto.FileName),
        new SqlParameter("@FilePath", fileDto.FilePath)
    };

            int rowsAffected = await _context.Database.ExecuteSqlRawAsync("EXEC InsertFileRecord @FileName, @FilePath", parameters);
            return rowsAffected > 0;
        }

        public async Task<FileRecord?> GetFileByNameAsync(string fileName)
        {
            return _context.Files
                .FromSqlRaw("EXEC GetFileByName @FileName", new SqlParameter("@FileName", fileName))
                .AsEnumerable()  
                .FirstOrDefault();
        }



    }
}
