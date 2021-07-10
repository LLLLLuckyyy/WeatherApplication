using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;
using WeatherApplication.Domain.Interfaces.ResponseModels.Weather;
using WeatherApplication.Infrastructure.Data.OperationsWithModels;
using WeatherApplication.Infrastructure.Data.WebRootPathConnection;
using WeatherApplication.Infrastructure.Data.WorkWithFiles;

namespace WeatherApplication.Infrastructure.Data
{
    public class WeatherRepository : IWeatherRepo
    {
        private readonly WeatherAppContext context;
        private readonly IMapper mapper;

        //Contains web root folder path
        private readonly RootFolder folder;

        public WeatherRepository(WeatherAppContext context, IMapper mapper, RootFolder folder)
        {
            this.context = context;
            this.mapper = mapper;
            this.folder = folder;
        }

        public async Task AddWeatherAsync(AddWeatherRequest request)
        {
            var weatherModel = mapper.Map<WeatherModel>(request);
            await context.WeatherModels.AddAsync(weatherModel);
            await context.SaveChangesAsync();
        }

        public async Task ArchiveWeatherInfoOfCityAsync(ArchiveWeatherRequest request)
        {
            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);
            //Gets weather models of certain city
            //in certain time interval
            //that are not archived
            var weatherHistory = context.WeatherModels
                .Where(wm => wm.CityModelId == request.CityId
                && (wm.ObservationTime < request.DateSearchingTo)
                && (wm.ObservationTime > request.DateSearchingFrom)
                && wm.IsArchived == false);

            //Converts weather history to response type
            var convertedWeatherHistory = weatherHistory
                .Select(wm => new GetWeatherHistoryResponse
                {
                    IdOfWeatherModel = wm.Id,
                    TemperatureWithTimeStamp = wm.Temperature.ToString() + " (" + wm.ObservationTime.ToString("yyyy/MM/dd hh:mm") + ")",
                    RainProbability = wm.RainProbability,
                    WindForce = wm.WindForce
                });

            if (convertedWeatherHistory != null && city != null)
            {
                string cityName = city.CityName;

                //Creates file in webRootPath/Files
                await FileOperations.CreateFileAsync(folder.Path, cityName, convertedWeatherHistory);

                //Archives files from webRootPath/Files
                FileOperations.CompressFile(folder.Path);

                //Marks certain weather models as archived
                await OperationsWithIsArchivedProperty.SetIsArchivedTrueAndSaveChanges(weatherHistory, context);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteAllArchivedWeatherInfoOfCityAsync(DeleteArchivedDataRequest request)
        {
            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);

            if (city != null)
            {
                string cityName = city.CityName;

                //Gets weather models of certain city
                //that are archived
                var weatherHistory = context.WeatherModels
                    .Where(wm => wm.CityModelId == request.CityId
                    && wm.IsArchived == true);

                //Deletes CityName.json file in webRootPath
                //and updates DrchivedData.zip file
                FileOperations.DeleteArchivedDataOfCity(folder.Path, cityName);
                FileOperations.CompressFile(folder.Path);
                //Marks sertain weather models as not archived
                await OperationsWithIsArchivedProperty.SetIsArchivedFalseAndSaveChanges(weatherHistory, context);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteWeatherAtCurrentTimeAsync(DeleteWeatherRequest request)
        {
            var weatherModel = context.WeatherModels.ToList()
                .LastOrDefault(wm => (wm.ObservationTime - request.ObservationTime).TotalMinutes < 15);

            if (weatherModel != null)
            {
                context.WeatherModels.Remove(weatherModel);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task EditWeatherAtCurrentTimeAsync(EditWeatherRequest request)
        {
            var weatherModel = context.WeatherModels.ToList()
                .LastOrDefault(wm => (wm.ObservationTime - request.ObservationTime).TotalMinutes < 15);

            if (weatherModel != null)
            {
                weatherModel.Temperature = request.TemperatureInCelsius;
                weatherModel.RainProbability = request.RainProbability;
                weatherModel.WindForce = request.WindForce;

                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<GetWeatherHistoryResponse> GetWeatherHistoryOfCity(GetWeatherHistoryRequest request)
        {
            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);
            
            var weatherHistory = context.WeatherModels.Where(wm => wm.CityModelId == request.CityId);

            if (weatherHistory != null && city != null)
            {
                //Converts weather history to response type
                var response = weatherHistory.Select(wm => new GetWeatherHistoryResponse
                {
                    IdOfWeatherModel = wm.Id,
                    TemperatureWithTimeStamp = wm.Temperature.ToString() + " (" + wm.ObservationTime.ToString("yyyy/MM/dd hh:mm") + ")",
                    RainProbability = wm.RainProbability,
                    WindForce = wm.WindForce
                });

                return response;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
