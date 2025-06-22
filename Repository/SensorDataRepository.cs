using Microsoft.EntityFrameworkCore;
using PlantMonitorApi.Data;
using PlantMonitorApi.Models;

namespace PlantMonitorApi.Repository
{
    public class SensorDataRepository(ApplicationDbContext ctx) : ISensorDataRepository
    {           
        public async Task AddAsync(SensorData entity)
        {
            await ctx.SensorReadings.AddAsync(entity);
            await ctx.SaveChangesAsync();
        }
        public async Task<IEnumerable<SensorData>> GetAllAsync() => await ctx.SensorReadings.ToListAsync();
    }
}
