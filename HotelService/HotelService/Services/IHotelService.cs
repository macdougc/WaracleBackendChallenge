using HotelService.Shared.Dtos;

namespace HotelService.Services;

public interface IHotelService
{
    Task<HotelDto> GetHotelByNameAsync(string name, CancellationToken cancellationToken);
}