﻿using Raspberry_Pi_Sensor_API.Models;

namespace Raspberry_Pi_Sensor_API.Services
{
    public interface ITemperatureService
    {
        Task<TemperatureRecordingResponse> SendTemperatureRecording(TemperatureRecordingRequest temperatureRecordingRequest);
    }
}
