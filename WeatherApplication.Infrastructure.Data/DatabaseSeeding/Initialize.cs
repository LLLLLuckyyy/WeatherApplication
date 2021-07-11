using System;
using System.Linq;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data.DatabaseSeeding
{
    //Initializing database with initial values
    public static class Initialize
    {
        public static void Seed(WeatherAppContext context)
        {
            if (!context.CityModels.Any() && !context.WeatherModels.Any())
            {
                var kyiv = new CityModel { CityName = "Kyiv" };
                var kharkiv = new CityModel { CityName = "Kharkiv" };
                var odessa = new CityModel { CityName = "Odessa" };

                context.CityModels.AddRange(kyiv, kharkiv, odessa);
                context.SaveChanges();

                var kyivWeather1 = new WeatherModel 
                {
                    CityModelId = 1,
                    Temperature = 20.5,
                    ObservationTime = new DateTime(2021, 7, 5, 9, 25, 0),
                    WindForce = 5,
                    RainProbability = 25
                };
                var kyivWeather2 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 27,
                    ObservationTime = new DateTime(2021, 7, 5, 14, 30, 0),
                    WindForce = 2,
                    RainProbability = 45
                };
                var kyivWeather3 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 23,
                    ObservationTime = new DateTime(2021, 7, 5, 19, 45, 0),
                    WindForce = 10,
                    RainProbability = 3
                };
                var kyivWeather4 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 23.5,
                    ObservationTime = new DateTime(2021, 7, 6, 11, 25, 0),
                    WindForce = 7,
                    RainProbability = 50
                };
                var kyivWeather5 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 28.5,
                    ObservationTime = new DateTime(2021, 7, 6, 16, 10, 0),
                    WindForce = 7,
                    RainProbability = 70
                };
                var kyivWeather6 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 30,
                    ObservationTime = DateTime.Now,
                    WindForce = 2,
                    RainProbability = 13
                };



                var kharkivWeather1 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 22.5,
                    ObservationTime = new DateTime(2021, 7, 5, 17, 25, 0),
                    WindForce = 3,
                    RainProbability = 53
                };
                var kharkivWeather2 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 25,
                    ObservationTime = new DateTime(2021, 7, 5, 11, 0, 0),
                    WindForce = 13,
                    RainProbability = 78
                };
                var kharkivWeather3 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 30,
                    ObservationTime = new DateTime(2021, 7, 5, 15, 0, 0),
                    WindForce = 15,
                    RainProbability = 77
                };
                var kharkivWeather4 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 29,
                    ObservationTime = new DateTime(2021, 7, 6, 17, 25, 0),
                    WindForce = 16,
                    RainProbability = 85
                };
                var kharkivWeather5 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 33,
                    ObservationTime = new DateTime(2021, 7, 7, 14, 30, 0),
                    WindForce = 9,
                    RainProbability = 56
                };
                var kharkivWeather6 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 28,
                    ObservationTime = DateTime.Now,
                    WindForce = 3,
                    RainProbability = 10
                };



                var odessaWeather1 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 30,
                    ObservationTime = new DateTime(2021, 7, 5, 12, 45, 0),
                    WindForce = 5,
                    RainProbability = 44
                };
                var odessaWeather2 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 35,
                    ObservationTime = new DateTime(2021, 7, 5, 15, 5, 0),
                    WindForce = 8,
                    RainProbability = 28
                };
                var odessaWeather3 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 32,
                    ObservationTime = new DateTime(2021, 7, 6, 16, 30, 0),
                    WindForce = 11,
                    RainProbability = 87
                };
                var odessaWeather4 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 35,
                    ObservationTime = new DateTime(2021, 7, 7, 14, 30, 0),
                    WindForce = 6,
                    RainProbability = 67
                };
                var odessaWeather5 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 28,
                    ObservationTime = new DateTime(2021, 7, 7, 19, 50, 0),
                    WindForce = 12,
                    RainProbability = 66
                };
                var odessaWeather6 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 33,
                    ObservationTime = DateTime.Now,
                    WindForce = 7,
                    RainProbability = 23
                };

                context.WeatherModels.AddRange(kyivWeather1, kyivWeather2, kyivWeather3, kyivWeather4, kyivWeather5, kyivWeather6);
                context.WeatherModels.AddRange(kharkivWeather1, kharkivWeather2, kharkivWeather3, kharkivWeather4, kharkivWeather5, kharkivWeather6);
                context.WeatherModels.AddRange(odessaWeather1, odessaWeather2, odessaWeather3, odessaWeather4, odessaWeather5, odessaWeather6);
                context.SaveChanges();
            }
        }
    }
}
