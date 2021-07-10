using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class DeleteWeatherRequest
    {
        [Required]
        [CorrectId]
        public int WeatherModelId { get; set; }
    }
}
