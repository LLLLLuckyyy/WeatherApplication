using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApplication.Domain.Core
{
    public class WeatherModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Temperature { get; set; }

        public DateTime ObservationTime { get; set; }

        public string TemperatureWithTimeStemp 
        {
            get 
            {
                return Temperature.ToString() + " (" + ObservationTime.ToString("yyyyMMddhhmm") + ")";
            }
        }

        public int CityId { get; set; }
    }
}
