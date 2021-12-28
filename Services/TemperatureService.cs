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
        public async Task<TemperatureRecordingResponse> SendTemperatureRecording(TemperatureRecordingRequest temperatureRecordingRequest)
        {
            var temperatureRecording = new TemperatureRecording()
            {
                Date = temperatureRecordingRequest.Date,
                TemperatureC = temperatureRecordingRequest.TemperatureC
            };

            var result = await temperatureRepository.SendTemperatureRecording(temperatureRecording);

            return new TemperatureRecordingResponse()
            {
                Date = result.Date,
                TemperatureC = result.TemperatureC,
                TemperatureF = result.TemperatureF
            };
        }
    }
}
