using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApplication.Domain.Core
{
    //Main model
    public class CityModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        [Range(1, 10)]
        public int NumberOfAllowedStatisticalModels { get; set; }

        public List<StatisticalModel> Statistics { get; set; }
        
        public List<WeatherModel> WeatherHistory { get; set; }
    }
}
