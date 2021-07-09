using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class AddWeatherInfoRequest
    {
        [Required]
        public double TemperatureInCelsius { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
