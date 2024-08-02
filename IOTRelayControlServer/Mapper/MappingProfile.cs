using AutoMapper;
using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Models;

namespace IOTRelayControlServer.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateSensorDto, Sensor>();
        CreateMap<UpdateSensorDto, Sensor>();
    }
}
