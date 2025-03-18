using System;
using System.IO;

namespace FP.Infrastructure.Utils
{
    public class FileManager
    {
        private readonly string _baseDirectory;

        public FileManager(string baseDirectory)
        {
            _baseDirectory = baseDirectory;
            if (!Directory.Exists(_baseDirectory))
            {
                Directory.CreateDirectory(_baseDirectory);
            }
        }

        private string GetFilePath(string fileName) => Path.Combine(_baseDirectory, fileName);

        public void WriteToFile(string fileName, string content)
        {
            try
            {
                string filePath = GetFilePath(fileName);

                // Asegurar que la carpeta existe antes de escribir
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    if (!string.IsNullOrEmpty(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                }

                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(content);
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Error writing to file: {fileName}", ex);
            }
        }

        public string ReadFromFile(string fileName)
        {
            try
            {
                string filePath = GetFilePath(fileName);
                return File.Exists(filePath) ? File.ReadAllText(filePath) : string.Empty;
            }
            catch (Exception ex)
            {
                throw new IOException($"Error reading file: {fileName}", ex);
            }
        }
    }
}
