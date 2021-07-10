using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;
using WeatherApplication.Domain.Interfaces.ResponseModels.Weather;

namespace WeatherApplication.Domain.Interfaces
{
    public interface IWeatherRepo
    {
        //Adds weather model to database
        Task AddWeatherAsync(AddWeatherRequest request);

        //Edits certain weather model in database
        Task EditWeatherAsync(EditWeatherRequest request);

        //Creates CityName.json file in webRootPath/Files
        //and (creates/updates) ArchivedData.zip file in web root path
        Task ArchiveWeatherInfoOfCityAsync(ArchiveWeatherRequest request);

        //Deletes CityName.json file in webRootPath/Files
        //and updates ArchivedData.zip file in web root path
        Task DeleteAllArchivedWeatherInfoOfCityAsync(DeleteArchivedDataRequest request);

        //Returns weather history of certain city
        //(list of weather model Id and temperature with timestamp)
        IEnumerable<GetWeatherHistoryResponse> GetWeatherHistoryOfCity(GetWeatherHistoryRequest request);

        //Deletes weather model from database
        Task DeleteWeatherAsync(DeleteWeatherRequest request);
    }
}
