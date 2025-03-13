using FP.Application.Services;
using FP.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace FP.Tests.Services
{
    [TestClass]
    public class FileServiceTests
    {
        private IFileService _fileService;
        private string _testDirectory;
        private string _testFilePath;
        private ILogger<FileService> _logger;

        [TestInitialize]
        public void Setup()
        {
            // 🟡 Versión inicial sin optimización (valores hardcodeados)
            /*
            _fileService = new FileService(null);
            */

            // ✅ Versión optimizada: Configurar Logger y ruta de prueba
            _testDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestFiles");
            _testFilePath = Path.Combine(_testDirectory, "test.txt");

            if (!Directory.Exists(_testDirectory))
            {
                Directory.CreateDirectory(_testDirectory);
            }

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = loggerFactory.CreateLogger<FileService>();

            _fileService = new FileService(_logger);
        }

        [TestMethod]
        public void SaveFile_ShouldCreateFile_WithCorrectContent()
        {
            // Act
            _fileService.SaveFile(_testFilePath, "Hello, TDD!");

            // 🛠️ Imprimir la ruta que estamos buscando
            Console.WriteLine($"Checking file at: {_testFilePath}");

            // Assert
            Assert.IsTrue(File.Exists(_testFilePath), $"El archivo no fue creado en la ruta esperada: {_testFilePath}");

            string content = File.ReadAllText(_testFilePath);
            Assert.AreEqual("Hello, TDD!", content, "El contenido del archivo no es el esperado.");
        }


        [TestMethod]
        public void ReadFile_ShouldReturnEmpty_WhenFileDoesNotExist()
        {
            // Act
            var content = _fileService.ReadFile("nonexistent.txt");

            // Esperar un breve tiempo para asegurar que el sistema libere el archivo
            System.Threading.Thread.Sleep(100);

            // Assert
            Assert.AreEqual(string.Empty, content, "El contenido debería ser vacío cuando el archivo no existe.");
        }


        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFilePath))
            {
                int attempts = 0;
                while (attempts < 5)
                {
                    try
                    {
                        using (var stream = new FileStream(_testFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            stream.Close();
                        }

                        File.SetAttributes(_testFilePath, FileAttributes.Normal);
                        File.Delete(_testFilePath);
                        break;
                    }
                    catch (IOException)
                    {
                        System.Threading.Thread.Sleep(50);
                        attempts++;
                    }
                }
            }
        }


    }
}
