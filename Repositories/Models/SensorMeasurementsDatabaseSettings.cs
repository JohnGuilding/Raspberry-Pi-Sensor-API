namespace Raspberry_Pi_Sensor_API.Repositories.Models
{
    public class SensorMeasurementsDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string TemperatureCollectionName { get; set; } = null!;
    }
}
