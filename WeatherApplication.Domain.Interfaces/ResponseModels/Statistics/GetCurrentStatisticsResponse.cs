namespace WeatherApplication.Domain.Interfaces.ResponseModels.Statistics
{
    public class GetCurrentStatisticsResponse
    {
        public string CityName { get; set; }

        public double MaxTemperature { get; set; }
        
        public double MinTemperature { get; set; }
        
        public double AverageTemperature { get; set; }
        
        public string TemperatureAtTheCurrentTime { get; set; }
    }
}
