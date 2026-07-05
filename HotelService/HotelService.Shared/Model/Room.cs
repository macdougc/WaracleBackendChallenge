namespace HotelService.Shared.Model;

public class Room
{
    public Guid Id { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = null!;

    public void AddBooking(Booking booking)
    {
        (Bookings ?? []).Add(booking);
    }
}
