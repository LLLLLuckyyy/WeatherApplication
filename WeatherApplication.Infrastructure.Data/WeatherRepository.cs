using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;
using WeatherApplication.Infrastructure.Data.WebRootPathConnection;
using WeatherApplication.Infrastructure.Data.WorkWithFiles;

namespace WeatherApplication.Infrastructure.Data
{
    public class WeatherRepository : IWeatherRepo
    {
        private readonly WeatherAppContext context;
        private readonly IMapper mapper;
        private readonly RootFolder folder;

        public WeatherRepository(WeatherAppContext context, IMapper mapper, RootFolder folder)
        {
            this.context = context;
            this.mapper = mapper;
            this.folder = folder;
        }

        public async Task AddCityWeatherInfoTimeAsync(AddWeatherInfoRequest request)
        {
            var weatherModel = mapper.Map<WeatherModel>(request);
            await context.WeatherModels.AddAsync(weatherModel);
            await context.SaveChangesAsync();
        }

        public async Task ArchiveCityWeatherInfoAsync(ArchiveWeatherInfoRequest request)
        {
            var weatherModels = context.WeatherModels
                .Where(wm => wm.CityId == request.CityId
                && (wm.ObservationTime < request.DateSearchingTo)
                && (wm.ObservationTime > request.DateSearchingFrom));
            
            if (weatherModels != null)
            {
                await FileOperations.CreateAndFillFileAsync(folder.Path, weatherModels);
                await FileOperations.CompressFileAsync(folder.Path);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteWeatherInfoAsync(DeleteWeatherInfoRequest request)
        {
            var weatherModel = context.WeatherModels.SingleOrDefault(wm => wm.Id == request.WeatherModelId);
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

        public async Task EditCityWeatherInfoAsync(EditWeatherInfoRequest request)
        {
            var weatherModel = context.WeatherModels.SingleOrDefault(wm => wm.Id == request.WeatherModelId);

            if (weatherModel != null)
            {
                weatherModel.ObservationTime = request.ObservationTime;
                weatherModel.Temperature = request.TemperatureInCelsius;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<WeatherModel> GetWeatherHistory(GetWeatherHistoryRequest request)
        {
            var weatherModels = context.WeatherModels.Where(wm => wm.CityId == request.CityId).ToList();
            if (weatherModels != null)
            {
                return weatherModels;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
