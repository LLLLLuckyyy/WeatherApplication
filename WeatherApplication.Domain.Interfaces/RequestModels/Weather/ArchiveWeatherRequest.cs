using System;
using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class ArchiveWeatherRequest
    {
        [Required]
        public DateTime DateSearchingFrom { get; set; }
        [Required]
        public DateTime DateSearchingTo { get; set; }
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
