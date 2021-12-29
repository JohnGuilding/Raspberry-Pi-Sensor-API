namespace Raspberry_Pi_Sensor_API.Models
{
    public class TemperatureReadingResponse
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF {  get; set; }
    }
}
