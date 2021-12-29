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
        private readonly ILogger<TemperatureController> logger;

        public TemperatureController(ITemperatureService temperatureService, ILogger<TemperatureController> logger)
        {
            this.temperatureService = temperatureService;
            this.logger = logger;
        }

        /// <summary>
        /// Gets all of the temperature readings
        /// </summary>
        /// <returns>A list of temperature reading responses</returns>
        [HttpGet(Name = "GetTemperatureReadings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTemperatureReadings()
        {
            var result = await temperatureService.GetTemperatureReadings();

            return Ok(result);
        }

        /// <summary>
        /// Sends a temperature reading to be stored
        /// </summary>
        /// <param name="temperatureReadingRequest">The temperature reading</param>
        /// <returns>A single temperature reading response</returns>
        [HttpPost(Name = "SendTemperatureReading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendTemperature(TemperatureReadingRequest temperatureReadingRequest)
        {
            var result = await temperatureService.SendTemperatureReading(temperatureReadingRequest);

            if (result == null) // TODO: Add validation
            {
                return BadRequest(result);
            }
            return Created(string.Empty, result);
        }
    }
}