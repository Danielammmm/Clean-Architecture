using FP.Application.Interfaces;
using FP.Domain.Configuration;
using FP.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FP.Tests.Services
{
    [TestClass]
    public class ConfigurationServiceTests
    {
        private IConfigurationService _configService;

        [TestInitialize]
        public void Setup()
        {
            // Simular una configuración en memoria
            var configData = new Dictionary<string, string>
            {
                { "ConfigSettings:StoragePath", "C:\\TestFiles" },
                { "ConfigSettings:MaxFileSize", "512000" },
                { "ConfigSettings:EnableLogging", "true" }
            };

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configData)
                .Build();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            var logger = loggerFactory.CreateLogger<ConfigurationService>();

            _configService = new ConfigurationService(configuration, logger);
        }

        [TestMethod]
        public void GetConfiguration_ShouldReturn_ValidSettings()
        {
            // ❌ Etapa 1: Prueba fallida (Método GetConfiguration() no existe)
            // Assert.IsNotNull(_configService.GetConfiguration()); // ⚠️ Error de compilación

            // 🟡 Etapa 2: Prueba pasa, pero con valores hardcodeados
            /*
            var config = _configService.GetConfiguration();
            Assert.AreEqual("C:\\Default", config.StoragePath);  // ⚠️ Fallaría si no es "C:\\Default"
            */

            // ✅ Etapa 3: Prueba pasa con implementación optimizada
            var config = _configService.GetConfiguration();

            Assert.IsNotNull(config);
            Assert.AreEqual("C:\\TestFiles", config.StoragePath);
            Assert.AreEqual(512000, config.MaxFileSize);
            Assert.IsTrue(config.EnableLogging);
        }
    }
}
