using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.City;

namespace WeatherApplication.Domain.Interfaces
{
    public interface ICityRepo
    {
        Task AddCityAsync(AddCityRequest request);
        CityModel GetCity(GetCityRequest request);
        Task DeleteCityAsync(DeleteCityRequest request);
    }
}
