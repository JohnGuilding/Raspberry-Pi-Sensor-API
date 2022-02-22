using Raspberry_Pi_Sensor_API.Domain.Models;
using Raspberry_Pi_Sensor_API.Models;
using Raspberry_Pi_Sensor_API.Repositories;

namespace Raspberry_Pi_Sensor_API.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly ITemperatureRepository temperatureRepository;

        public TemperatureService(ITemperatureRepository temperatureRepository)
        {
            this.temperatureRepository = temperatureRepository;
        }

        public async Task<List<TemperatureReadingResponse>> GetTemperatureReadings()
        {
            var readings = await temperatureRepository.GetTemperatureReadings();

            var readingsResponse = readings
                .Select(reading => new TemperatureReadingResponse()
                {
                    ReadingDate = reading.Date,
                    TemperatureC = reading.TemperatureC,
                    TemperatureF = reading.TemperatureF,
                })
                .ToList();

            return readingsResponse;
        }

        public async Task<TemperatureReadingResponse> SendTemperatureReading(TemperatureReadingRequest temperatureReadingRequest)
        {
            var temperatureReading = new TemperatureReading()
            {
                Date = temperatureReadingRequest.Date,
                TemperatureC = temperatureReadingRequest.TemperatureC
            };

            var result = await temperatureRepository.SendTemperatureReading(temperatureReading);

            return new TemperatureReadingResponse()
            {
                ReadingDate = result.Date,
                TemperatureC = result.TemperatureC,
                TemperatureF = result.TemperatureF
            };
        }
    }
}
