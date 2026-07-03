using AutoMapper;
using HotelService.Shared.Data;
using HotelService.Shared.Dtos;
using static HotelService.Shared.Exceptions.NotFoundException;

namespace HotelService.Services;

public class BookingService(IHotelRepository hotelRepository, IMapper mapper) : IBookingService
{

    public async Task<BookingDto> GetBookingByReferenceAsync(int reference)
    {
        var booking = await hotelRepository.GetBookingByBookingReferenceAsync(reference);

        EnsureWasFound(booking, $"No booking found for reference {reference}");

        return mapper.Map<BookingDto>(booking);
    }
}
