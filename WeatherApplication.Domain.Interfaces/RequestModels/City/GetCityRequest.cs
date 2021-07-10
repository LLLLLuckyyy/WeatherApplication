using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.City
{
    public class GetCityRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
