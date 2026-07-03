using HotelService.Shared.Dtos;
using HotelService.Shared.Model;

namespace HotelService.Shared.Data;

public interface IHotelRepository
{
    public Task<Hotel?> GetHotelByNameAsync(string name);
}
