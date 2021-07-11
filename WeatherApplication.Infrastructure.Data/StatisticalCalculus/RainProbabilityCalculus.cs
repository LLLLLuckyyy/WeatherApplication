using System;
using System.Linq;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.StatisticalCalculus
{
    public class RainProbabilityCalculus
    {
        //Calculates rain probability values
        //For correct calculation you must pass weather models with same CityId
        public static double GetMinRainProbability(IQueryable<WeatherModel> weatherHistory)
        {
            var minRainProbability = GetRainProbability(weatherHistory).Min();

            return minRainProbability;
        }

        public static double GetMaxRainProbability(IQueryable<WeatherModel> weatherHistory)
        {
            var maxRainProbability = GetRainProbability(weatherHistory).Max();

            return maxRainProbability;
        }

        public static double GetAverageRainProbability(IQueryable<WeatherModel> weatherHistory)
        {
            var avgRainProbability = GetRainProbability(weatherHistory).Average();

            return avgRainProbability;
        }

        public static string GetCurrentRainProbability(IQueryable<WeatherModel> weatherHistory)
        {
            var closestModel = weatherHistory.ToList()
                .Where(wm => DateTime.Now.Subtract(wm.ObservationTime).TotalHours < 1)
                .LastOrDefault();

            if (closestModel == null)
            {
                return "Absent";
            }

            var currentRainProbability = closestModel.RainProbability;
            return currentRainProbability.ToString();
        }

        public static IQueryable<double> GetRainProbability(IQueryable<WeatherModel> weatherHistory)
        {
            return weatherHistory.Select(wm => wm.RainProbability);
        }
    }
}
