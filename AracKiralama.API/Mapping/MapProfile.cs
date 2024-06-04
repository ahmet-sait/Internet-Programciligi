using AutoMapper;
using AracKiralama.API.Dtos;
using AracKiralama.API.Models;
using AracKiralama.Dtos;
using AracKiralama.Models;

namespace AracKiralama.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
