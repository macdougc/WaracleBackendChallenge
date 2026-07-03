using HotelService.Shared.Dtos;
using HotelService.Shared.Model;

namespace HotelService.Services;

public interface IHotelService
{
    Task<HotelDto> GetHotelByNameAsync(string name);
}