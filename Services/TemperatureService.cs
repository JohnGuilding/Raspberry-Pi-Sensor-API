using Raspberry_Pi_Sensor_API.Models;

namespace Raspberry_Pi_Sensor_API.Services
{
    public class TemperatureService : ITemperatureService
    {
        public async TemperatureRecordingResponse SendTemperatureRecording(TemperatureRecordingRequest temperatureRecordingRequest)
        {
            var result = await temperatureRespository.SendTemperatureRecording(temperatureRecordingRequest);

            return new TemperatureRecordingResponse()
            {

            };
        }
    }
}
