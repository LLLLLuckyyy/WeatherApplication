using System;
using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class DeleteWeatherRequest
    {
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
