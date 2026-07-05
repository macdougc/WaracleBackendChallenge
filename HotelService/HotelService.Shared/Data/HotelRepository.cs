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

    public async Task<Hotel?> GetHotelByNameAsync(string name, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        return await _context.Hotels
            .Include(h => h.Rooms)
            .FirstOrDefaultAsync(h => h.Name == name, cancellationToken);
    }

    public async Task<Booking?> GetBookingByBookingReferenceAsync(int bookingRefernce, CancellationToken cancellationToken)
    {
        return await _context.Bookings
            .Include(b => b.Room)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.BookingReference == bookingRefernce, cancellationToken);
    }

    public async Task<Room?> GetRoomByIdAsync(Guid roomId, CancellationToken cancellationToken)
    {
        return await _context.Rooms
            .Include(r => r.Bookings)
            .FirstOrDefaultAsync(r => r.Id == roomId, cancellationToken);
    }

    public void AddBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
