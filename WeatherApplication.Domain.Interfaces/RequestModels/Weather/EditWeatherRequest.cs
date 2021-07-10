using System;
using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class EditWeatherRequest
    {
        [Required]
        public double TemperatureInCelsius { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
    }
}
