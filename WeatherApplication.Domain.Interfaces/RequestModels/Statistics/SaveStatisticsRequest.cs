using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Statistics
{
    public class SaveStatisticsRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
