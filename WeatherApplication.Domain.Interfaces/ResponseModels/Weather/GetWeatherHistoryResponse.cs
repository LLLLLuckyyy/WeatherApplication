namespace WeatherApplication.Domain.Interfaces.ResponseModels.Weather
{
    public class GetWeatherHistoryResponse
    {
        public int IdOfWeatherModel { get; set; }
        public string TemperatureWithTimeStamp { get; set; }
    }
}
