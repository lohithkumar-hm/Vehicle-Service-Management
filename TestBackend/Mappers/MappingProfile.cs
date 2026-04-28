using AutoMapper;
using TestBackend.DTOs;
using TestBackend.Model.Entity;

namespace TestBackend.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
        }
    }
}
