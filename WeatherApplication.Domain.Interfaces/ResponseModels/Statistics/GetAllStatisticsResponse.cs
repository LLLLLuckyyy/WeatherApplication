namespace WeatherApplication.Domain.Interfaces.ResponseModels.Statistics
{
    public class GetAllStatisticsResponse
    {
        public int StatisticalModelId { get; set; }

        public string DateModelCreated { get; set; }

        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public double AverageTemperature { get; set; }
    }
}
