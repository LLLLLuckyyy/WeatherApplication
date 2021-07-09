using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Statistics;
using WeatherApplication.Infrastructure.Data.StatisticalCalculus;

namespace WeatherApplication.Infrastructure.Data
{
    public class StatisticsRepository : IStatisticsRepo
    {
        private readonly WeatherAppContext context;

        public StatisticsRepository(WeatherAppContext context)
        {
            this.context = context;
        }

        public StatisticalModel GetStatistics(GetStatisticsRequest request)
        {
            var weatherModels = context.WeatherModels.Where(wm => wm.CityId == request.CityId);

            if (weatherModels != null)
            {
                return new StatisticalModel
                {
                    AverageTemperature = TemperatureCalculus.GetAverageTemperature(weatherModels),
                    MinTemperature = TemperatureCalculus.GetMinTemperature(weatherModels),
                    MaxTemperature = TemperatureCalculus.GetMaxTemperature(weatherModels),
                    TemperatureAtTheRequestTime = TemperatureCalculus.GetCurrentTemperature(weatherModels),
                    CityId = request.CityId
                }; 
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task SaveStatistics(SaveStatisticsRequest request)
        {
            var weatherModels = context.WeatherModels.Where(wm => wm.CityId == request.CityId);

            if (weatherModels != null)
            {
                var statistics = new StatisticalModel
                {
                    AverageTemperature = TemperatureCalculus.GetAverageTemperature(weatherModels),
                    MinTemperature = TemperatureCalculus.GetMinTemperature(weatherModels),
                    MaxTemperature = TemperatureCalculus.GetMaxTemperature(weatherModels),
                    TemperatureAtTheRequestTime = TemperatureCalculus.GetCurrentTemperature(weatherModels),
                    CityId = request.CityId
                };

                await context.StatisticalModels.AddAsync(statistics);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteStatistics( DeleteStatisticsRequest request)
        {
            var statisticalModel = context.StatisticalModels.SingleOrDefault(sm => sm.Id == request.StatisticalModelId);
            if (statisticalModel != null)
            {
                context.StatisticalModels.Remove(statisticalModel);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
