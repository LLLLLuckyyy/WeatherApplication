using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.StatisticalCalculus
{
    //weather models must be with the same CityId
    public static class TemperatureCalculus
    {
        public static double GetMinTemperature(IQueryable<WeatherModel> weatherModels)
        {
            var minTemperature = GetTemperature(weatherModels).Min();

            return minTemperature;
        }

        public static double GetMaxTemperature(IQueryable<WeatherModel> weatherModels)
        {
            var maxTemperature = GetTemperature(weatherModels).Max();

            return maxTemperature;
        }

        public static double GetAverageTemperature(IQueryable<WeatherModel> weatherModels)
        {
            var avgTemperature = GetTemperature(weatherModels).Average();

            return avgTemperature;
        }

        public static double GetCurrentTemperature(IQueryable<WeatherModel> weatherModels)
        {
            var now = DateTime.Now;
            var closestModel = weatherModels
                .Where(wm => now.Subtract(wm.ObservationTime).Hours < 1)
                .LastOrDefault();

            var currentTemperature = closestModel.Temperature;
            return currentTemperature;
        }

        public static IQueryable<double> GetTemperature(IQueryable<WeatherModel> weatherModels)
        {
            return weatherModels.Select(wm => wm.Temperature);
        }
    }
}
