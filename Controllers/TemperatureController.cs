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
        /// Gets a temperature recording
        /// </summary>
        /// <returns>A single temperature recording response</returns>
        [HttpGet(Name = "GetTemperatureRecording")]
        public async Task<IActionResult> GetTemperature()
        {
            var result = new TemperatureRecordingResponse
            {
                Date = DateTime.UtcNow,
                TemperatureC = 21,
            };

            return Ok(result);
        }

        /// <summary>
        /// Sends a temperature recording to be stored
        /// </summary>
        /// <param name="temperatureRecordingRequest">The temperature recording</param>
        /// <returns>A single temperature recording response</returns>
        [HttpPost(Name = "SendTemperatureRecording")]
        public async Task<IActionResult> SendTemperature(TemperatureRecordingRequest temperatureRecordingRequest)
        {
            var result = await temperatureService.SendTemperatureRecording(temperatureRecordingRequest);

            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}