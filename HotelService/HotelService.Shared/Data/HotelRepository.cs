using HotelService.Shared.Dtos;
using HotelService.Shared.Model;
using Microsoft.EntityFrameworkCore;
using static HotelService.Shared.Helpers.DateHelper;

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
            .FirstOrDefaultAsync(b => b.BookingReference == bookingRefernce, cancellationToken);
    }

    public async Task<Room?> GetRoomByIdAsync(Guid roomId, CancellationToken cancellationToken)
    {
        return await _context.Rooms
            .Include(r => r.Bookings)
            .FirstOrDefaultAsync(r => r.Id == roomId, cancellationToken);
    }

    public async Task<IEnumerable<Room>?> GetAvailableRoomsAsync(SearchAvailableRoomsDto searchAvailableRoomsDto, CancellationToken cancellationToken)
    {
        return await _context.Rooms
            .Include(h => h.Bookings)
            .Where(h => h.Capacity >= searchAvailableRoomsDto.NumberOfPeople &&
                        (h.Bookings == null || !h.Bookings.Any(b => (b.StartDate <= searchAvailableRoomsDto.EndDate && b.StartDate >= searchAvailableRoomsDto.StartDate)
                                                                    || (b.EndDate <= searchAvailableRoomsDto.EndDate && b.EndDate >= searchAvailableRoomsDto.StartDate))))
            .ToListAsync(cancellationToken);
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
