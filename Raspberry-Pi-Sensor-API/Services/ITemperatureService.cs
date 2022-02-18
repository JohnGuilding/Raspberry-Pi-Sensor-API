using Raspberry_Pi_Sensor_API.Models;

namespace Raspberry_Pi_Sensor_API.Services
{
    public interface ITemperatureService
    {
        Task<List<TemperatureReadingResponse>> GetTemperatureReadings();

        Task<TemperatureReadingResponse> SendTemperatureReading(TemperatureReadingRequest temperatureReadingRequest);

    }
}
