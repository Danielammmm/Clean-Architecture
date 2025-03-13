using FP.Application.Interfaces;
using FP.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FP.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ConfigSettings _configSettings;
        private readonly ILogger<ConfigurationService> _logger;

        public ConfigurationService(IConfiguration configuration, ILogger<ConfigurationService> logger)
        {
            _logger = logger;
            _logger.LogInformation("Initializing ConfigurationService...");

            // Etapa 1: Función inexistente (Prueba fallida)
            // ConfigSettings GetConfiguration();  //  No implementada

            // Etapa 2: Implementación mínima sin configuración dinámica
            /*
            _configSettings = new ConfigSettings
            {
                StoragePath = "C:\\Default",
                MaxFileSize = 0,
                EnableLogging = false
            };
            _logger.LogInformation("Default configuration loaded.");
            */

            // Etapa 3 - Versión Optimizada: Carga la configuración desde appsettings.json con soporte de DI
            var config = configuration.GetSection("ConfigSettings").Get<ConfigSettings>();

            if (config == null)
            {
                _logger.LogError("Missing ConfigSettings in appsettings.json.");
                throw new InvalidOperationException("ConfigSettings is missing in appsettings.json");
            }

            _configSettings = config;
            _logger.LogInformation("Configuration loaded: StoragePath={StoragePath}, MaxFileSize={MaxFileSize}, EnableLogging={EnableLogging}",
                _configSettings.StoragePath, _configSettings.MaxFileSize, _configSettings.EnableLogging);
        }

        public ConfigSettings GetConfiguration()
        {
            _logger.LogInformation("Returning configuration settings.");
            return _configSettings;
        }
    }
}
