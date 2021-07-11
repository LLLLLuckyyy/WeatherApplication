using System;
using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class EditWeatherRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
        [Required]
        [Range(-50, 50)]
        public double TemperatureInCelsius { get; set; }
        [Required]
        [Range(0, 100)]
        public double RainProbability { get; set; }
        [Required]
        [Range(0, 40)]
        public double WindForce { get; set; }

        [Required]
        public DateTime ObservationTime { get; set; }
    }
}
