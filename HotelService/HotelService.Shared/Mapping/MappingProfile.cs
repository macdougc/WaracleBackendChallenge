using AutoMapper;
using HotelService.Shared.Dtos;
using HotelService.Shared.Model;

namespace HotelService.Shared.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Hotel, HotelDto>();
        CreateMap<Room, RoomDto>();
        CreateMap<User, UserDto>();
    }
}
