namespace HotelService.Shared.Dtos;

public class BookingDto
{
    public Guid Id { get; set; }

    public string BookingReference { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime BookedDate { get; set; }

    public string BookingEmail { get; set; } = null!;

    public int NumberOfPeople { get; set; }

    public RoomDto Room { get; set; } = null!;
}
