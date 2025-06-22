using Microsoft.EntityFrameworkCore;
using PlantMonitorApi.Data;
using PlantMonitorApi.Repository;
using PlantMonitorApi.Service;

namespace PlantMonitorApi.Infrastructure
{
    public static class DIContainer
    {
        // Extention class 

        public static IServiceCollection AddPlantMonitoringInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(opts=> opts.UseSqlite(connectionString));

            services.AddScoped<ISensorDataRepository, SensorDataRepository>();
            services.AddScoped<ISensorDataService, SensorDataService>();

            return services;
        }
    }
}
