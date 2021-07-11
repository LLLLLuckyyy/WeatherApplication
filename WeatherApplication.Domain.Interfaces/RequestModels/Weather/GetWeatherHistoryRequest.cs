using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class GetWeatherHistoryRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
