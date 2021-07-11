namespace WeatherApplication.Domain.Interfaces.ResponseModels.City
{
    public class GetCityResponse
    {
        public string CityName { get; set; }

        public int NumberOfAllowedStatisticalModels { get; set; }
    }
}
