using PlantMonitorApi.Dto;
using PlantMonitorApi.Models;

namespace PlantMonitorApi.Service
{
    public interface ISensorDataService
    {
        public Task StoreAsync(SensorDataDto data);

        public Task<IEnumerable<SensorDataDto>> GetAllAsync();
    }
}
