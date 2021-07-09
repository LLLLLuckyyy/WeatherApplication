using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Core
{
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
        public double TemperatureAtTheRequestTime { get; set; }

        public int CityId { get; set; }
    }
}
