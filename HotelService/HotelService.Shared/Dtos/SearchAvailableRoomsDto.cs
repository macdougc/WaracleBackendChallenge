namespace HotelService.Shared.Dtos;

public class SearchAvailableRoomsDto
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int NumberOfPeople { get; set; }
}
