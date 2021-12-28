using Microsoft.AspNetCore.Mvc;
using Raspberry_Pi_Sensor_API.Models;

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

        /// <summary>
        /// Gets a temperature recording
        /// </summary>
        /// <returns>A single temperature recording response</returns>
        [HttpGet(Name = "GetTemperatureRecording")]
        public TemperatureRecordingResponse GetTemperature()
        {
            return new TemperatureRecordingResponse
            {
                Date = DateTime.UtcNow,
                TemperatureC = 21,
            };
        }

        /// <summary>
        /// Sends a temperature recording to be stored
        /// </summary>
        /// <param name="temperatureRecordingRequest">The temperature recording</param>
        /// <returns>A single temperature recording response</returns>
        [HttpPost(Name = "SendTemperatureRecording")]
        public TemperatureRecordingResponse SendTemperature(TemperatureRecordingRequest temperatureRecordingRequest)
        {
            return new TemperatureRecordingResponse
            {
                Date = DateTime.UtcNow,
                TemperatureC = 21,
            };
        }
    }
}