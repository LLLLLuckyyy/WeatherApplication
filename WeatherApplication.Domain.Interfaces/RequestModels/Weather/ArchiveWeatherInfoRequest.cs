using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class ArchiveWeatherInfoRequest
    {
        public DateTime DateSearchingFrom { get; set; }
        public DateTime DateSearchingTo { get; set; }
        public int CityId { get; set; }
    }
}
