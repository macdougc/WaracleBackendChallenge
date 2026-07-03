namespace HotelService.Shared.Dtos;

public class HotelDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public IEnumerable<RoomDto> Rooms { get; set; } = null!;
}
