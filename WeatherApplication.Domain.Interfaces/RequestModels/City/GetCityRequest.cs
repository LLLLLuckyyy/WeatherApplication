using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.City
{
    public class GetCityRequest
    {
        [Required]
        public int CityId { get; set; }
    }
}
