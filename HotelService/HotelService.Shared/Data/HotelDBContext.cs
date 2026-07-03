using System;
using HotelService.Shared.Dtos;
using HotelService.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Shared.Data;

public class HotelDBContext : DbContext
{
    private readonly string? _connectionString;

    public HotelDBContext(DbContextOptions<HotelDBContext> options)
        : base(options)
    {
    }

    // Optional constructor used when creating the context directly with a connection string
    public HotelDBContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DbSet<Hotel> Hotels { get; set; } = null!;

    public DbSet<Room> Rooms { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(h => h.Id);
            entity.HasMany(h => h.Rooms)
                  .WithOne(r => r.Hotel)
                  .HasForeignKey("HotelId");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(r => r.Id);
        });
    }
}
