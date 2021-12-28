using Raspberry_Pi_Sensor_API.Domain.Models;
using Raspberry_Pi_Sensor_API.Models;

namespace Raspberry_Pi_Sensor_API.Repositories
{
    public interface ITemperatureRepository
    {
        Task<TemperatureRecording> SendTemperatureRecording(TemperatureRecording temperatureRecording);
    }
}
