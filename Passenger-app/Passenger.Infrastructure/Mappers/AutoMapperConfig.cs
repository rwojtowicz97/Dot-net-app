using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        =>  new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Node, NodeDto>();
                cfg.CreateMap<Route, RouteDto>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Driver, DriverDetailsDto>();
                cfg.CreateMap<Driver, DriverDto>();
                cfg.CreateMap<Vehicle, VehicleDto>();
            }).CreateMapper();
        
    }
}