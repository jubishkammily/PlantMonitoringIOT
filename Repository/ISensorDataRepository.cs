using PlantMonitorApi.Models;

namespace PlantMonitorApi.Repository
{
    public interface ISensorDataRepository
    {
        public Task AddAsync(SensorData entity);
        Task<IEnumerable<SensorData>> GetAllAsync();

    }
}
