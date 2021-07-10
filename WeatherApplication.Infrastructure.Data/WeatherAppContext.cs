using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityModel>()
                .HasMany(c => c.WeatherHistory)
                .WithOne(wh => wh.CityModel)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityModel>()
                .HasMany(c => c.Statistics)
                .WithOne(s => s.CityModel)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
