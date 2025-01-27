﻿using AspNetCoreSignalR.Hubs;
using AspNetCoreSignalR.Services;
using Coravel.Invocable;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Jobs;

public class CheckForWeatherUpdates : IInvocable
{
    public CheckForWeatherUpdates(WeatherServices services, IHubContext<WeatherHub, IWeatherHub> hub)
    {
        Hub = hub;
        Services = services;
    }

    public IHubContext<WeatherHub, IWeatherHub> Hub { get; }
    public WeatherServices Services { get; }
    private static readonly Random rnd = new Random();

    public async Task Invoke()
    {
        Models.WeatherForecast[] forecasts = Services.GetForecasts().ToArray();
        await Hub.Clients.All.WeatherUpdated(forecasts[rnd.Next(0, forecasts.Length)]);
    }
}