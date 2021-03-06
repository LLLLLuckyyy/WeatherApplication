namespace WeatherApplication.Domain.Interfaces.ResponseModels.Statistics
{
    public class GetAllStatisticsResponse
    {
        public int StatisticalModelId { get; set; }

        public string DateModelCreated { get; set; }


        public double MaxTemperature { get; set; }

        public double MinTemperature { get; set; }

        public double AverageTemperature { get; set; }


        public double MaxRainProbability { get; set; }

        public double MinRainProbability { get; set; }

        public double AverageRainProbability { get; set; }


        public double MaxWindForce { get; set; }

        public double MinWindForce { get; set; }

        public double AverageWindForce { get; set; }
    }
}
