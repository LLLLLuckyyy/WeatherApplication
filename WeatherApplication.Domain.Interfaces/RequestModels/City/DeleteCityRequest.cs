using System.ComponentModel.DataAnnotations;
using WeatherApplication.Domain.Interfaces.ValidationAttributes;

namespace WeatherApplication.Domain.Interfaces.RequestModels.City
{
    public class DeleteCityRequest
    {
        [Required]
        [CorrectId]
        public int CityId { get; set; }
    }
}
