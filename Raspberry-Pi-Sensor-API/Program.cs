using Raspberry_Pi_Sensor_API.Repositories;
using Raspberry_Pi_Sensor_API.Repositories.Models;
using Raspberry_Pi_Sensor_API.Services;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultname"]}.vault.azure.net/"),
        new DefaultAzureCredential());
}

// Added DefaultAzureCredentialOptions to prevent a 401 (Unauthorised) response when trying to access Key Vault from Visual Studio
var options = new DefaultAzureCredentialOptions { ExcludeVisualStudioCredential = true };
var client = new SecretClient(new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"), new DefaultAzureCredential(options));
var secret = await client.GetSecretAsync("Raspberry-Pi-Sensor-Measurements-Connection-String");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("GetTempPolicy",
        builder =>
        {
            builder.AllowAnyOrigin();
        });
});

builder.Services.Configure<SensorMeasurementsDatabaseSettings>(
    builder.Configuration.GetSection("SensorMeasurementsDatabase"));
builder.Services.PostConfigure<SensorMeasurementsDatabaseSettings>(x => x.ConnectionString = secret.Value.Value);

builder.Services.AddTransient<ITemperatureService, TemperatureService>();
builder.Services.AddSingleton<ITemperatureRepository, TemperatureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();