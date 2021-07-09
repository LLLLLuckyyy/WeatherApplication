using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class EditWeatherInfoRequest
    {
        [Required]
        public double TemperatureInCelsius { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        public int WeatherModelId { get; set; }
    }
}
