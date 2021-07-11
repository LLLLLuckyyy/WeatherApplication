using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Domain.Core
{
    //Weather model of certain city
    public class WeatherModel
    {
        [Key]
        public int Id { get; set; }
        //In Celsius degrees
        [Required]
        [Range(-50, 50)]
        public double Temperature { get; set; }
        //In percents
        [Required]
        [Range(0, 100)]
        public double RainProbability { get; set; }
        //meters per second
        [Required]
        [Range(0, 40)]
        public double WindForce { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        public bool IsArchived { get; set; }

        
        public int? CityModelId { get; set; }
        public CityModel CityModel { get; set; }
    }
}
