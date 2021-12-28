using Microsoft.AspNetCore.Mvc;

namespace Raspberry_Pi_Sensor_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ILogger<TemperatureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTemperatureRecording")]
        public TemperatureRecording GetTemperature()
        {
            return new TemperatureRecording
            {
                Date = DateTime.UtcNow,
                TemperatureC = 21,
            };
        }
    }
}