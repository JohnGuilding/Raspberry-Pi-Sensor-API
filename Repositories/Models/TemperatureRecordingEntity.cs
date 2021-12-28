using MongoDB.Bson.Serialization.Attributes;

namespace Raspberry_Pi_Sensor_API.Repositories.Models
{
    public class TemperatureRecordingEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Date")]
        public DateTime ReadingDate { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

    }
}
