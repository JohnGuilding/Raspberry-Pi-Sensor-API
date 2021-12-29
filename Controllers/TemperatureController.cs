using Microsoft.AspNetCore.Mvc;
using Raspberry_Pi_Sensor_API.Models;
using Raspberry_Pi_Sensor_API.Services;

namespace Raspberry_Pi_Sensor_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly ITemperatureService temperatureService;
        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ITemperatureService temperatureService, ILogger<TemperatureController> logger)
        {
            this.temperatureService = temperatureService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a temperature reading
        /// </summary>
        /// <returns>A single temperature reading response</returns>
        [HttpGet(Name = "GetTemperatureReading")]
        public async Task<IActionResult> GetTemperature()
        {
            var result = new TemperatureReadingResponse
            {
                Date = DateTime.UtcNow,
                TemperatureC = 21,
            };

            return Ok(result);
        }

        /// <summary>
        /// Sends a temperature reading to be stored
        /// </summary>
        /// <param name="temperatureReadingRequest">The temperature reading</param>
        /// <returns>A single temperature reading response</returns>
        [HttpPost(Name = "SendTemperatureReading")]
        public async Task<IActionResult> SendTemperature(TemperatureReadingRequest temperatureReadingRequest)
        {
            var result = await temperatureService.SendTemperatureReading(temperatureReadingRequest);

            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}