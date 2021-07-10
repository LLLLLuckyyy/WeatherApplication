using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class AddWeatherRequest
    {
        [Required]
        public double TemperatureInCelsius { get; set; }
        [Required]
        public double RainProbability { get; set; }
        [Required]
        public double WindForce { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
