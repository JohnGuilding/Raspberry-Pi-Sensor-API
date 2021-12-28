namespace Raspberry_Pi_Sensor_API.Models
{
    public class TemperatureRecordingRequest
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
    }
}
