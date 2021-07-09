using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.City;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;

namespace WeatherApplication.Infrastructure.Data.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddCityRequest, CityModel>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName));

            CreateMap<AddWeatherInfoRequest, WeatherModel>()
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.ObservationTime, opt => opt.MapFrom(src => src.ObservationTime))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.TemperatureInCelsius));
        }
    }
}
