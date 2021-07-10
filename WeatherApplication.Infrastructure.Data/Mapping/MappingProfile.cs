using AutoMapper;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.City;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;
using WeatherApplication.Domain.Interfaces.ResponseModels.Statistics;

namespace WeatherApplication.Infrastructure.Data.Mapping
{
    //Map certain types
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddCityRequest, CityModel>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName));

            CreateMap<AddWeatherRequest, WeatherModel>()
                .ForMember(dest => dest.CityModelId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.ObservationTime, opt => opt.MapFrom(src => src.ObservationTime))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.TemperatureInCelsius));

            CreateMap<StatisticalModel, GetAllStatisticsResponse>()
                .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(src => src.MaxTemperature))
                .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(src => src.MinTemperature))
                .ForMember(dest => dest.AverageTemperature, opt => opt.MapFrom(src => src.AverageTemperature))
                .ForMember(dest => dest.DateModelCreated, opt => opt.MapFrom(src => src.DateStatisticsCreated.ToString("yyyy/MM/dd hh:mm")))
                .ForMember(dest => dest.StatisticalModelId, opt => opt.MapFrom(src => src.Id));

            CreateMap<StatisticalModel, GetStatisticsWithCurrentTemperatureResponse>()
                .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(src => src.MaxTemperature))
                .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(src => src.MinTemperature))
                .ForMember(dest => dest.AverageTemperature, opt => opt.MapFrom(src => src.AverageTemperature))
                .ForMember(dest => dest.TemperatureAtTheCurrentTime, opt => opt.MapFrom(src => src.TemperatureAtTheCurrentTime));
        }
    }
}
