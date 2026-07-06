using HotelService.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Shared.Data;

public class HotelDBContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=NPE5690B4BC894;Database=HotelService;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");
            entity.HasKey(h => h.Id);
            entity.HasMany(h => h.Rooms)
                  .WithOne(r => r.Hotel)
                  .HasForeignKey("HotelId");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");
            entity.HasKey(r => r.Id);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");
            entity.HasKey(r => r.BookingReference);
            entity.Property(r => r.BookingReference).ValueGeneratedOnAdd();
        });
    }
}
