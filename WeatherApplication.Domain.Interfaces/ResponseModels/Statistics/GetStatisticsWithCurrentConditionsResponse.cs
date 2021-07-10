namespace WeatherApplication.Domain.Interfaces.ResponseModels.Statistics
{
    public class GetStatisticsWithCurrentConditionsResponse
    {
        public string CityName { get; set; }

        public double MaxTemperature { get; set; }
        
        public double MinTemperature { get; set; }
        
        public double AverageTemperature { get; set; }
        
        public string CurrentTemperature { get; set; }

        public double MaxRainProbability { get; set; }
        
        public double MinRainProbability { get; set; }
        
        public double AverageRainProbability { get; set; }
        
        public string CurrentRainProbability { get; set; }

        public double MaxWindForce { get; set; }
        
        public double MinWindForce { get; set; }
        
        public double AverageWindForce { get; set; }
        
        public string CurrentWindForce { get; set; }
    }
}
