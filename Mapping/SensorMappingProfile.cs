using AutoMapper;
using PlantMonitorApi.Dto;
using PlantMonitorApi.Models;

namespace PlantMonitorApi.Mapping
{
    public class SensorMappingProfile : Profile
    {
        public SensorMappingProfile()
        {
            CreateMap<SensorData, SensorDataDto>()
                .ReverseMap()
                  // Clients shouldn’t set these—let EF/your auditing layer do it
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore()); ;
        }
    }
}
