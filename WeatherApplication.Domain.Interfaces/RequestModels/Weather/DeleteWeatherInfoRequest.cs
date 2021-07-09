using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class DeleteWeatherInfoRequest
    {
        [Required]
        public int WeatherModelId { get; set; }
    }
}
