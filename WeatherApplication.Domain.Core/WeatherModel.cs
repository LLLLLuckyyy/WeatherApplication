using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Domain.Core
{
    //Weather model of certain city
    public class WeatherModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        public DateTime ObservationTime { get; set; }
        [Required]
        public bool IsArchived { get; set; }

        
        public int? CityModelId { get; set; }
        public CityModel CityModel { get; set; }
    }
}
