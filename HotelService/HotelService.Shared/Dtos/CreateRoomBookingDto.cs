namespace HotelService.Shared.Dtos;

public class CreateRoomBookingDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int NumberOfPeople { get; set; }

    public Guid RoomId { get; set; }

    public Guid UserId { get; set; }
}
