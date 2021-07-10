using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Domain.Core
{
    //Statistical model of certain city
    public class StatisticalModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double MaxTemperature { get; set; }
        [Required]
        public double MinTemperature { get; set; }
        [Required]
        public double AverageTemperature { get; set; }
        [Required]
        public string CurrentTemperature { get; set; }

        [Required]
        public double MaxRainProbability { get; set; }
        [Required]
        public double MinRainProbability { get; set; }
        [Required]
        public double AverageRainProbability { get; set; }
        [Required]
        public string CurrentRainProbability { get; set; }

        [Required]
        public double MaxWindForce { get; set; }
        [Required]
        public double MinWindForce { get; set; }
        [Required]
        public double AverageWindForce { get; set; }
        [Required]
        public string CurrentWindForce { get; set; }

        [Required]
        public DateTime DateStatisticsCreated { get; set; }

        
        public int? CityModelId { get; set; }
        public CityModel CityModel { get; set; }
    }
}
