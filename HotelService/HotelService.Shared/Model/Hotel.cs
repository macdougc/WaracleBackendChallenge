namespace HotelService.Shared.Model;

public class Hotel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = null!;
}
