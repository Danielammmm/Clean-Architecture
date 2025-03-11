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

            _configSettings = configuration.GetSection("ConfigSettings").Get<ConfigSettings>() ?? new ConfigSettings();

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
