using System;
using eMedicalManagementMinimalAPI.DataAccess.Models;

namespace eMedicalManagementMinimalAPI.APIs
{
    public class WeatherApi
    {
        public static void RegisterApis(WebApplication app)
        {
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var weather = app.MapGroup("/api").WithTags("Weather Forecast");


            weather.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            // Add below lines of code to add hello world endpoint
            weather.MapGet("/hello-world", () => "Hello World")
                .WithName("Hello World")
                .WithOpenApi();
        }
    }
}

