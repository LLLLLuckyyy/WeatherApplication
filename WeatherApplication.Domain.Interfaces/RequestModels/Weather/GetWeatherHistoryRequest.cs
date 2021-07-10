using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class GetWeatherHistoryRequest
    {
        [CorrectId]
        public int CityId { get; set; }
    }
}
