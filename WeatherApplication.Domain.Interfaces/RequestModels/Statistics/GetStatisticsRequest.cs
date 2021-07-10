using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Statistics
{
    public class GetStatisticsRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
