using AutoMapper;
using PlantMonitorApi.Dto;
using PlantMonitorApi.Models;
using PlantMonitorApi.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlantMonitorApi.Service
{
    public class SensorDataService(ISensorDataRepository sensorDataRepository,
        IMapper mapper) : ISensorDataService
    {
        public async Task<IEnumerable<SensorDataDto>> GetAllAsync()
        {            
            var entity = await sensorDataRepository.GetAllAsync();
            var dto = mapper.Map< IEnumerable<SensorDataDto>>(entity);
            return dto;
        }

        public async Task StoreAsync(SensorDataDto data)
        {
            var entity = mapper.Map<SensorData>(data);
            await sensorDataRepository.AddAsync(entity);
        }
    }
}

