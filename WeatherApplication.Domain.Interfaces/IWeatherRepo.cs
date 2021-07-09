using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;

namespace WeatherApplication.Domain.Interfaces
{
    public interface IWeatherRepo
    {
        Task AddCityWeatherInfoTimeAsync(AddWeatherInfoRequest request);
        Task EditCityWeatherInfoAsync(EditWeatherInfoRequest request);
        Task ArchiveCityWeatherInfoAsync(ArchiveWeatherInfoRequest request);
        List<WeatherModel> GetWeatherHistory(GetWeatherHistoryRequest request);
        Task DeleteWeatherInfoAsync(DeleteWeatherInfoRequest request);
    }
}
