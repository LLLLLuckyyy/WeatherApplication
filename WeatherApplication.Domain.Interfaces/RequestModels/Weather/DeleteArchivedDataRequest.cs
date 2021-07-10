using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.Weather
{
    public class DeleteArchivedDataRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
