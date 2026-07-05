using HotelService.Shared.Model;

namespace HotelService.Shared.Data;

public interface IHotelRepository
{
    public Task<Hotel?> GetHotelByNameAsync(string name, CancellationToken cancellationToken);

    Task<Booking?> GetBookingByBookingReferenceAsync(int bookingRefernce, CancellationToken cancellationToken);

    Task<Room?> GetRoomByIdAsync(Guid roomId, CancellationToken cancellationToken);

    void AddBooking(Booking booking);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
