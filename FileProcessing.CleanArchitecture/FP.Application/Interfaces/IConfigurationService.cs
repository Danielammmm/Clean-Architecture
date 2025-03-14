using FP.Domain.Configuration;

namespace FP.Application.Interfaces
{
    public interface IConfigurationService
    {
        ConfigSettings GetConfiguration();
    }
}

