using HotelService.Shared.Dtos;

namespace HotelService.Services;

public interface IBookingService
{
    Task<BookingDto> GetBookingByReferenceAsync(int reference, CancellationToken cancellationToken);

    Task<BookingDto?> CreateRoomBooking(CreateRoomBookingDto createRoomBookingDto, CancellationToken cancellationToken);
}