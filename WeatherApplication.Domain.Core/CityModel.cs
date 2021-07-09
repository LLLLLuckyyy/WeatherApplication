using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Core
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }

        public StatisticalModel Statistics { get; set; }
        public List<WeatherModel> WeatherHistory { get; set; }
    }
}
