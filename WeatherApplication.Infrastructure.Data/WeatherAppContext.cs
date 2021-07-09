using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApplication.Domain.Core;

namespace WeatherApplication.Infrastructure.Data
{
    public class WeatherAppContext : DbContext
    {
        public DbSet<CityModel> CityModels { get; set; }
        public DbSet<WeatherModel> WeatherModels { get; set; }
        public DbSet<StatisticalModel> StatisticalModels { get; set; }

        public WeatherAppContext(DbContextOptions<WeatherAppContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreation(DbModelBuilder modelBuilder)
        {
        }
    }
}
