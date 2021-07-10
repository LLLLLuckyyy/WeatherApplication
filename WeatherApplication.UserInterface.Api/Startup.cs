using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApplication.Domain.Interfaces;
using WeatherApplication.Infrastructure.Data;
using WeatherApplication.Infrastructure.Data.Mapping;
using WeatherApplication.Infrastructure.Data.WebRootPathConnection;

namespace WeatherApplication.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment Environment { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICityRepo, CityRepository>();
            services.AddTransient<IWeatherRepo, WeatherRepository>();
            services.AddTransient<IStatisticsRepo, StatisticsRepository>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WeatherAppContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            services.AddSingleton(new RootFolder { Path = Environment.WebRootPath });

            services.AddMemoryCache();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
