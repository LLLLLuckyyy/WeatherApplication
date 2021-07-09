using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class GetWeatherHistoryRequest
    {
        public int CityId { get; set; }
    }
}
