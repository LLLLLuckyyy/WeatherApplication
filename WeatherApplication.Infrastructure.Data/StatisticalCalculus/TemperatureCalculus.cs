using System;
using System.Linq;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.StatisticalCalculus
{
    //Calculates temperature values
    //For correct calculation you must pass weather models with same CityId
    public static class TemperatureCalculus
    {
        public static double GetMinTemperature(IQueryable<WeatherModel> weatherHistory)
        {
            var minTemperature = GetTemperature(weatherHistory).Min();

            return minTemperature;
        }

        public static double GetMaxTemperature(IQueryable<WeatherModel> weatherHistory)
        {
            var maxTemperature = GetTemperature(weatherHistory).Max();

            return maxTemperature;
        }

        public static double GetAverageTemperature(IQueryable<WeatherModel> weatherHistory)
        {
            var avgTemperature = GetTemperature(weatherHistory).Average();

            return avgTemperature;
        }

        public static string GetCurrentTemperature(IQueryable<WeatherModel> weatherHistory)
        {
            var closestModel = weatherHistory.ToList()
                .Where(wm => DateTime.Now.Subtract(wm.ObservationTime).TotalHours < 1)
                .LastOrDefault();

            if (closestModel == null)
            {
                return "Absent";
            }

            var currentTemperature = closestModel.Temperature;
            return currentTemperature.ToString();
        }

        public static IQueryable<double> GetTemperature(IQueryable<WeatherModel> weatherHistory)
        {
            return weatherHistory.Select(wm => wm.Temperature);
        }
    }
}
