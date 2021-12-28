using Raspberry_Pi_Sensor_API.Domain.Models;

namespace Raspberry_Pi_Sensor_API.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        public Task<TemperatureRecording> SendTemperatureRecording(TemperatureRecording temperatureRecording)
        {
            throw new NotImplementedException();
        }
    }
}
