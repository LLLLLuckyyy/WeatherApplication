using Microsoft.Extensions.Caching.Memory;
using System;
using WeatherApplication.Domain.Interfaces.ResponseModels.Statistics;

namespace WeatherApplication.Infrastructure.Data.Caching
{
    public static class CacheOperations
    {
        public static void SetCache(IMemoryCache cache, int key, GetStatisticsWithCurrentConditionsResponse cachingValue, int minutes)
        {
            cache.Set(key, cachingValue, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minutes)
            });
        }
    }
}
