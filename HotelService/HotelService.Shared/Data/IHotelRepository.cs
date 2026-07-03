using HotelService.Shared.Model;

namespace HotelService.Shared.Data;

public interface IHotelRepository
{
    public Task<Hotel?> GetHotelByNameAsync(string name);

    Task<Booking?> GetBookingByBookingReferenceAsync(int bookingRefernce);
}
