using FP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FP.API.Controllers
{
    [ApiController]
    [Route("api/config")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigurationService _configService;

        public ConfigController(IConfigurationService configService)
        {
            _configService = configService;
        }

        [HttpGet]
        public IActionResult GetConfig()
        {
            return Ok(_configService.GetConfiguration());
        }
    }
}
