using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Domain.Interfaces.RequestModels.Statistics;
using WeatherApplication.Domain.Interfaces.ResponseModels.Statistics;

namespace WeatherApplication.Domain.Interfaces
{
    public interface IStatisticsRepo
    {
        //Returns statistics of certain city with current temperature
        //from cache if exists or creates response and put it in cache
        GetStatisticsWithCurrentConditionsResponse GetStatisticsAndCurrentConditions(GetStatisticsRequest request);

        //Returns all statistical models of certain city from database
        List<GetAllStatisticsResponse> GetAllStatisticalModelsOfCity(GetStatisticsRequest request);

        //Saves statistics of certain city to database and caches it
        Task SaveStatisticsAndCurrentConditionsAsync(SaveStatisticsRequest request);

        //Deletes statistical model from database by Id
        Task DeleteStatisticalModelAsync(DeleteStatisticsRequest request);
    }
}
