using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.StatisticalCalculus
{
    public class WindForceCalculus
    {
        public static double GetMinWindForce(IQueryable<WeatherModel> weatherHistory)
        {
            var minWindForce = GetWindForce(weatherHistory).Min();

            return minWindForce;
        }

        public static double GetMaxWindForce(IQueryable<WeatherModel> weatherHistory)
        {
            var maxWindForce = GetWindForce(weatherHistory).Max();

            return maxWindForce;
        }

        public static double GetAverageWindForce(IQueryable<WeatherModel> weatherHistory)
        {
            var avgWindForce = GetWindForce(weatherHistory).Average();

            return avgWindForce;
        }

        public static string GetCurrentWindForce(IQueryable<WeatherModel> weatherHistory)
        {
            var closestModel = weatherHistory.ToList()
                .Where(wm => DateTime.Now.Subtract(wm.ObservationTime).TotalHours < 1)
                .LastOrDefault();

            if (closestModel == null)
            {
                return "Absent";
            }

            var currentWindForce = closestModel.WindForce;
            return currentWindForce.ToString();
        }

        public static IQueryable<double> GetWindForce(IQueryable<WeatherModel> weatherHistory)
        {
            return weatherHistory.Select(wm => wm.WindForce);
        }
    }
}
