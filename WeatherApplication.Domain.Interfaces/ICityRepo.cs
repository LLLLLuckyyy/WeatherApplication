using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces.RequestModels.City;
using WeatherApplication.Domain.Interfaces.ResponseModels.City;

namespace WeatherApplication.Domain.Interfaces
{
    public interface ICityRepo
    {
        //Adds new city to database
        Task AddCityAsync(AddCityRequest request);

        //Returns city name by Id
        GetCityResponse GetCity(GetCityRequest request);

        //Deletes city from database
        Task DeleteCityAsync(DeleteCityRequest request);
    }
}
