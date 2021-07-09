using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Domain.Interfaces.RequestModels.City;

namespace WeatherApplication.Infrastructure.Data
{
    public class CityRepository : ICityRepo
    {
        private readonly WeatherAppContext context;
        private readonly IMapper mapper;

        public CityRepository(WeatherAppContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddCityAsync(AddCityRequest request)
        {
            var sameCityInDatabase = context.CityModels.SingleOrDefault(c => c.CityName == request.CityName);
            if (sameCityInDatabase == null)
            {
                CityModel city = mapper.Map<CityModel>(request);
                await context.CityModels.AddAsync(city);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteCityAsync(DeleteCityRequest request)
        {
            var cityToDelete = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);
            if (cityToDelete != null)
            {
                context.CityModels.Remove(cityToDelete);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public CityModel GetCity(GetCityRequest request)
        {
            var city = context.CityModels.SingleOrDefault(c => c.Id == request.CityId);
            if (city != null)
            {
                return city;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
