using Raspberry_Pi_Sensor_API.Repositories;
using Raspberry_Pi_Sensor_API.Repositories.Models;
using Raspberry_Pi_Sensor_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<SensorMeasurementsDatabaseSettings>(
    builder.Configuration.GetSection("SensorMeasurementsDatabase"));

builder.Services.AddTransient<TemperatureService>();
builder.Services.AddSingleton<TemperatureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
