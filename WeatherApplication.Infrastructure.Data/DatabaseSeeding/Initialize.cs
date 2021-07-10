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
                var kharkiv = new CityModel { CityName = "Kharkiv" };
                var kyiv = new CityModel { CityName = "Kyiv" };
                var odessa = new CityModel { CityName = "Odessa" };

                context.CityModels.AddRange(kharkiv, kyiv, odessa);
                context.SaveChanges();

                var kyivWeather1 = new WeatherModel 
                {
                    CityModelId = 1,
                    Temperature = 20.5,
                    ObservationTime = new DateTime(2021, 7, 5, 9, 25, 0)
                };
                var kyivWeather2 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 27,
                    ObservationTime = new DateTime(2021, 7, 5, 14, 30, 0)
                };
                var kyivWeather3 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 23,
                    ObservationTime = new DateTime(2021, 7, 5, 19, 45, 0)
                };
                var kyivWeather4 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 23.5,
                    ObservationTime = new DateTime(2021, 7, 6, 11, 25, 0)
                };
                var kyivWeather5 = new WeatherModel
                {
                    CityModelId = 1,
                    Temperature = 28.5,
                    ObservationTime = new DateTime(2021, 7, 6, 16, 10, 0)
                };



                var kharkivWeather1 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 22.5,
                    ObservationTime = new DateTime(2021, 7, 5, 17, 25, 0)
                };
                var kharkivWeather2 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 25,
                    ObservationTime = new DateTime(2021, 7, 5, 11, 0, 0)
                };
                var kharkivWeather3 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 30,
                    ObservationTime = new DateTime(2021, 7, 5, 15, 0, 0)
                };
                var kharkivWeather4 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 29,
                    ObservationTime = new DateTime(2021, 7, 6, 17, 25, 0)
                };
                var kharkivWeather5 = new WeatherModel
                {
                    CityModelId = 2,
                    Temperature = 33,
                    ObservationTime = new DateTime(2021, 7, 7, 14, 30, 0)
                };



                var odessaWeather1 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 30,
                    ObservationTime = new DateTime(2021, 7, 5, 12, 45, 0)
                };
                var odessaWeather2 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 35,
                    ObservationTime = new DateTime(2021, 7, 5, 15, 5, 0)
                };
                var odessaWeather3 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 32,
                    ObservationTime = new DateTime(2021, 7, 6, 16, 30, 0)
                };
                var odessaWeather4 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 35,
                    ObservationTime = new DateTime(2021, 7, 7, 14, 30, 0)
                };
                var odessaWeather5 = new WeatherModel
                {
                    CityModelId = 3,
                    Temperature = 28,
                    ObservationTime = new DateTime(2021, 7, 7, 19, 50, 0)
                };

                context.WeatherModels.AddRange(kyivWeather1, kyivWeather2, kyivWeather3, kyivWeather4, kyivWeather5);
                context.WeatherModels.AddRange(kharkivWeather1, kharkivWeather2, kharkivWeather3, kharkivWeather4, kharkivWeather5);
                context.WeatherModels.AddRange(odessaWeather1, odessaWeather2, odessaWeather3, odessaWeather4, odessaWeather5);
                context.SaveChanges();
            }
        }
    }
}
