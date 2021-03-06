using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Statistics
{
    public class DeleteStatisticsRequest
    {
        [Required]
        [CorrectId]
        public int StatisticalModelId { get; set; }
    }
}
