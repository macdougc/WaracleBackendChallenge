using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelService.Shared.Dtos;
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

    public async Task<List<Hotel>> GetAllHotels()
    {
        return await _context.Hotels
            .Include(h => h.Rooms)
            .ToListAsync();
    }

    public async Task AddHotel(Hotel hotel)
    {
        if (hotel == null) throw new ArgumentNullException(nameof(hotel));

        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
    }
}
