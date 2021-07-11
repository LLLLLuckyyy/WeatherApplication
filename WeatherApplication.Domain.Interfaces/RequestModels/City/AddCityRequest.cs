using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.City
{
    public class AddCityRequest
    {
        [Required]
        public string CityName { get; set; }
        [Required]
        [Range(1, 10)]
        public int NumberOfAllowedStatisticalModels { get; set; }
    }
}
