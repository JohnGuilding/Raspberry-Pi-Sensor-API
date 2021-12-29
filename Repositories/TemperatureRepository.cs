using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Raspberry_Pi_Sensor_API.Domain.Models;
using Raspberry_Pi_Sensor_API.Repositories.Models;

namespace Raspberry_Pi_Sensor_API.Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly IMongoCollection<TemperatureReadingEntity> temperatureCollection;

        public TemperatureRepository(
            IOptions<SensorMeasurementsDatabaseSettings> sensorMeasurementDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                sensorMeasurementDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                sensorMeasurementDatabaseSettings.Value.DatabaseName);

            temperatureCollection = mongoDatabase.GetCollection<TemperatureReadingEntity>(
                sensorMeasurementDatabaseSettings.Value.TemperatureCollectionName);
        }

        public async Task<TemperatureReading> SendTemperatureReading(TemperatureReading temperatureReading)
        {
            var newTemperatureReading = new TemperatureReadingEntity()
            {
                ReadingDate = temperatureReading.Date,
                TemperatureC = temperatureReading.TemperatureC,
                TemperatureF = temperatureReading.TemperatureF,
            };

            await temperatureCollection.InsertOneAsync(newTemperatureReading);

            return temperatureReading;
        }
    }
}
