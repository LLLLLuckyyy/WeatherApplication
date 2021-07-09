using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.Statistics;

namespace WeatherApplication.Domain.Interfaces
{
    public interface IStatisticsRepo
    {
        StatisticalModel GetStatistics(GetStatisticsRequest request);
        Task SaveStatistics(SaveStatisticsRequest request);
        Task DeleteStatistics(DeleteStatisticsRequest request);
    }
}
