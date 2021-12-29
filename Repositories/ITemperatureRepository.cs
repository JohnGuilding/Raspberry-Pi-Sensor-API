using Raspberry_Pi_Sensor_API.Domain.Models;

namespace Raspberry_Pi_Sensor_API.Repositories
{
    public interface ITemperatureRepository
    {
        Task<TemperatureReading> SendTemperatureReading(TemperatureReading temperatureReading);
    }
}
