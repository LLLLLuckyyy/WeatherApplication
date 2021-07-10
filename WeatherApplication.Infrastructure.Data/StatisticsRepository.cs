using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Statistics;
using WeatherApplication.Domain.Interfaces.ResponseModels.Statistics;
using WeatherApplication.Infrastructure.Data.Caching;
using WeatherApplication.Infrastructure.Data.StatisticalCalculus;

namespace WeatherApplication.Infrastructure.Data
{
    public class StatisticsRepository : IStatisticsRepo
    {
        private readonly WeatherAppContext context;
        private readonly IMapper mapper;
        private IMemoryCache memoryCache;

        public StatisticsRepository(WeatherAppContext context, IMemoryCache memoryCache, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }

        public GetCurrentStatisticsResponse GetCurrentStatisticsOfCity(GetStatisticsRequest request)
        {
            GetCurrentStatisticsResponse response = null;

            //Checks memory cache for fit value
            if (memoryCache.TryGetValue(request.CityId, out response))
            {
                return response;
            }

            //Gets not archived weather models of city
            var weatherHistory = context.WeatherModels.Where(wm => wm.CityModelId == request.CityId && wm.IsArchived == false);

            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);

            if (weatherHistory != null && city != null)
            {
                response = new GetCurrentStatisticsResponse
                {
                    CityName = city.CityName,
                    AverageTemperature = TemperatureCalculus.GetAverageTemperature(weatherHistory),
                    MinTemperature = TemperatureCalculus.GetMinTemperature(weatherHistory),
                    MaxTemperature = TemperatureCalculus.GetMaxTemperature(weatherHistory),
                    TemperatureAtTheCurrentTime = TemperatureCalculus.GetCurrentTemperature(weatherHistory)
                };

                //Sets new cache for 2 min.
                CacheOperations.SetCache(memoryCache, request.CityId, response, 2);

                return response;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<GetAllStatisticsResponse> GetAllStatisticalModelsOfCity(GetStatisticsRequest request)
        {
            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);
            var statisticalModels = context.StatisticalModels.Where(s => s.CityModelId == request.CityId);

            if (statisticalModels != null && city != null)
            {
                var response = statisticalModels.Select(s => mapper.Map<GetAllStatisticsResponse>(s)).ToList();
                return response;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task SaveStatisticsOfCityAsync(SaveStatisticsRequest request)
        {
            //Gets not archived weather models of certain city
            var weatherHistory = context.WeatherModels.Where(wm => wm.CityModelId == request.CityId && wm.IsArchived == false);

            if (weatherHistory != null)
            {
                var statistics = new StatisticalModel
                {
                    AverageTemperature = TemperatureCalculus.GetAverageTemperature(weatherHistory),
                    MinTemperature = TemperatureCalculus.GetMinTemperature(weatherHistory),
                    MaxTemperature = TemperatureCalculus.GetMaxTemperature(weatherHistory),
                    TemperatureAtTheCurrentTime = TemperatureCalculus.GetCurrentTemperature(weatherHistory),
                    CityModelId = request.CityId,
                    DateStatisticsCreated = DateTime.Now
                };

                //Sets new cache for 2 min. with every save request
                var cachingValue = mapper.Map<GetCurrentStatisticsResponse>(statistics);
                cachingValue.CityName = context.CityModels.SingleOrDefault(c => c.Id == request.CityId).CityName;
                CacheOperations.SetCache(memoryCache, request.CityId, cachingValue, 2);

                await context.StatisticalModels.AddAsync(statistics);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteStatisticalModelAsync(DeleteStatisticsRequest request)
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
