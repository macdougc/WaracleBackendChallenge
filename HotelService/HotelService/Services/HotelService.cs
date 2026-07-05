using AutoMapper;
using HotelService.Shared.Data;
using HotelService.Shared.Dtos;
using static HotelService.Shared.Exceptions.NotFoundException;

namespace HotelService.Services;

public class HotelService(IHotelRepository hotelRepository, IMapper mapper) : IHotelService
{

    public async Task<HotelDto> GetHotelByNameAsync(string name, CancellationToken cancellationToken)
    {
        var hotel = await hotelRepository.GetHotelByNameAsync(name, cancellationToken);

        EnsureWasFound(hotel, $"No hotel with name {name}");

        return mapper.Map<HotelDto>(hotel);
    }
}
