using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Raspberry_Pi_Sensor_API.Domain.Models;
using Raspberry_Pi_Sensor_API.Repositories.Models;

namespace Raspberry_Pi_Sensor_API.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly IMongoCollection<TemperatureRecordingEntity> temperatureCollection;

        public TemperatureRepository(IOptions<SensorMeasurementsDatabaseSettings> sensorMeasurementDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                sensorMeasurementDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                sensorMeasurementDatabaseSettings.Value.DatebaseName);

            temperatureCollection = mongoDatabase.GetCollection<TemperatureRecordingEntity>(
                sensorMeasurementDatabaseSettings.Value.TemperatureCollectionName);
        }

        public async Task<TemperatureRecording> SendTemperatureRecording(TemperatureRecording temperatureRecording)
        {
            var newTemperatureRecording = new TemperatureRecordingEntity()
            {
                ReadingDate = temperatureRecording.Date,
                TemperatureC = temperatureRecording.TemperatureC,
                TemperatureF = temperatureRecording.TemperatureF,
            };

            await temperatureCollection.InsertOneAsync(newTemperatureRecording);

            return temperatureRecording;
        }
    }
}
