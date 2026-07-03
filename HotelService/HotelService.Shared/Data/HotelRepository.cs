using HotelService.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Shared.Data;

public class HotelRepository : IHotelRepository
{
    private readonly HotelDBContext _context;

    public HotelRepository(HotelDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Hotel?> GetHotelByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return await _context.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Name == name);
    }

    public async Task<Booking?> GetBookingByBookingReferenceAsync(int bookingRefernce)
    {
        return await _context.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.BookingReference == bookingRefernce);
    }
}
