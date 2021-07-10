using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class EditWeatherRequest
    {
        [Required]
        public double TemperatureInCelsius { get; set; }
        [Required]
        public double RainProbability { get; set; }
        [Required]
        public double WindForce { get; set; }

        [Required]
        public DateTime ObservationTime { get; set; }
    }
}
