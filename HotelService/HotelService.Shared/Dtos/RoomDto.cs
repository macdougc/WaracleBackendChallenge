namespace HotelService.Shared.Dtos;

public class RoomDto
{
    public Guid Id { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }
}
