namespace HotelService.Shared.Model;

public class Booking
{
    public int BookingReference { get; init; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime BookedDate { get; set; }

    public int NumberOfPeople { get; set; }

    public string BookingEmail { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
