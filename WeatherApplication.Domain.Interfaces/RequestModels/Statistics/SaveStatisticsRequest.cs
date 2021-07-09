using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Statistics
{
    public class SaveStatisticsRequest
    {
        [Required]
        public int CityId { get; set; }
    }
}
