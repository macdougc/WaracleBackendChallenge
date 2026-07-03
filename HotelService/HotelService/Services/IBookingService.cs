using HotelService.Shared.Dtos;

namespace HotelService.Services;

public interface IBookingService
{
    Task<BookingDto> GetBookingByReferenceAsync(int reference);
}