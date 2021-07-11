using AutoMapper;
using WeatherApplication.Domain.Core;
using WeatherApplication.Domain.Interfaces.RequestModels.City;
using WeatherApplication.Domain.Interfaces.RequestModels.Weather;
using WeatherApplication.Domain.Interfaces.ResponseModels.Statistics;
using WeatherApplication.Domain.Interfaces.ResponseModels.Weather;

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
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.TemperatureInCelsius))
                .ForMember(dest => dest.RainProbability, opt => opt.MapFrom(src => src.RainProbability))
                .ForMember(dest => dest.WindForce, opt => opt.MapFrom(src => src.WindForce));

            CreateMap<StatisticalModel, GetAllStatisticsResponse>()
                .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(src => src.MaxTemperature))
                .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(src => src.MinTemperature))
                .ForMember(dest => dest.AverageTemperature, opt => opt.MapFrom(src => src.AverageTemperature))
                .ForMember(dest => dest.MaxRainProbability, opt => opt.MapFrom(src => src.MaxRainProbability))
                .ForMember(dest => dest.MinRainProbability, opt => opt.MapFrom(src => src.MinRainProbability))
                .ForMember(dest => dest.AverageRainProbability, opt => opt.MapFrom(src => src.AverageRainProbability))
                .ForMember(dest => dest.MaxWindForce, opt => opt.MapFrom(src => src.MaxWindForce))
                .ForMember(dest => dest.MinWindForce, opt => opt.MapFrom(src => src.MinWindForce))
                .ForMember(dest => dest.AverageWindForce, opt => opt.MapFrom(src => src.AverageWindForce))
                .ForMember(dest => dest.DateModelCreated, opt => opt.MapFrom(src => src.DateStatisticsCreated.ToString("yyyy/MM/dd hh:mm")))
                .ForMember(dest => dest.StatisticalModelId, opt => opt.MapFrom(src => src.Id));

            CreateMap<StatisticalModel, GetStatisticsWithCurrentConditionsResponse>()
                .ForMember(dest => dest.MaxTemperature, opt => opt.MapFrom(src => src.MaxTemperature))
                .ForMember(dest => dest.MinTemperature, opt => opt.MapFrom(src => src.MinTemperature))
                .ForMember(dest => dest.AverageTemperature, opt => opt.MapFrom(src => src.AverageTemperature))
                .ForMember(dest => dest.CurrentTemperature, opt => opt.MapFrom(src => src.CurrentTemperature))
                .ForMember(dest => dest.MaxRainProbability, opt => opt.MapFrom(src => src.MaxRainProbability))
                .ForMember(dest => dest.MinRainProbability, opt => opt.MapFrom(src => src.MinRainProbability))
                .ForMember(dest => dest.AverageRainProbability, opt => opt.MapFrom(src => src.AverageRainProbability))
                .ForMember(dest => dest.CurrentRainProbability, opt => opt.MapFrom(src => src.CurrentRainProbability))
                .ForMember(dest => dest.MaxWindForce, opt => opt.MapFrom(src => src.MaxWindForce))
                .ForMember(dest => dest.MinWindForce, opt => opt.MapFrom(src => src.MinWindForce))
                .ForMember(dest => dest.AverageWindForce, opt => opt.MapFrom(src => src.AverageWindForce))
                .ForMember(dest => dest.CurrentWindForce, opt => opt.MapFrom(src => src.CurrentWindForce));

            CreateMap<WeatherModel, GetWeatherHistoryResponse>()
                .ForMember(dest => dest.IdOfWeatherModel, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
                .ForMember(dest => dest.RainProbability, opt => opt.MapFrom(src => src.RainProbability))
                .ForMember(dest => dest.WindForce, opt => opt.MapFrom(src => src.WindForce))
                .ForMember(dest => dest.DateObservation, opt => opt.MapFrom(src => src.ObservationTime.ToString("yyyy/MM/dd hh:ss")));
        }
    }
}
