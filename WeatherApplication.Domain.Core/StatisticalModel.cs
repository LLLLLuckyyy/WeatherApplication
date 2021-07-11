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
        [Range(-50, 50)]
        public double MaxTemperature { get; set; }
        [Required]
        [Range(-50, 50)]
        public double MinTemperature { get; set; }
        [Required]
        [Range(-50, 50)]
        public double AverageTemperature { get; set; }
        [Required]
        public string CurrentTemperature { get; set; }

        [Required]
        [Range(0, 100)]
        public double MaxRainProbability { get; set; }
        [Required]
        [Range(0, 100)]
        public double MinRainProbability { get; set; }
        [Required]
        [Range(0, 100)]
        public double AverageRainProbability { get; set; }
        [Required]
        public string CurrentRainProbability { get; set; }

        [Required]
        [Range(0, 40)]
        public double MaxWindForce { get; set; }
        [Required]
        [Range(0, 40)]
        public double MinWindForce { get; set; }
        [Required]
        [Range(0, 40)]
        public double AverageWindForce { get; set; }
        [Required]
        public string CurrentWindForce { get; set; }

        [Required]
        public DateTime DateStatisticsCreated { get; set; }

        
        public int? CityModelId { get; set; }
        public CityModel CityModel { get; set; }
    }
}
