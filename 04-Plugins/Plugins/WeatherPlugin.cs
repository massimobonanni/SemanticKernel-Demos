using Microsoft.SemanticKernel;
using System.ComponentModel;

public class WeatherPlugin
{
    public class TaskModel
    {
        public int Id { get; set; }
    }

    [KernelFunction("weather_temperature")]
    [Description("Retrieve the current temperature based on location.")]
    [return: Description("The current temperature, or null if not found.")]
    public decimal? GetCurrentTemperature([Description("the name of the city")] string city)
    {

        return (decimal?)32.0; 
    }

    
    [KernelFunction("weather_forecast")]
    [Description("Retrieve the weather forecast for a given city.")]
    [return: Description("The weather forecast, or null if not found.")]
    public string? GetWeatherForecast([Description("the name of the city")] string city)
    {
        return "Sunny";
    }


}