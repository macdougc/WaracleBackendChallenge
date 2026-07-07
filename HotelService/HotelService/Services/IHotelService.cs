using HotelService.Shared.Dtos;

namespace HotelService.Services;

public interface IHotelService
{
    Task<HotelDto> GetHotelByNameAsync(string name, CancellationToken cancellationToken);

    Task<IEnumerable<RoomDto>> GetAvailableRoomsAsync(SearchAvailableRoomsDto searchAvailableRoomsDto, CancellationToken cancellationToken);

    Task CreateSeedingData(CancellationToken cancellationToken);

    Task RemoveAllData(CancellationToken cancellationToken);
}