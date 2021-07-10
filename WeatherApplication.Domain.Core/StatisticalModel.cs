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
        public string TemperatureAtTheCurrentTime { get; set; }
        [Required]
        public DateTime DateStatisticsCreated { get; set; }

        
        public int? CityModelId { get; set; }
        public CityModel CityModel { get; set; }
    }
}
