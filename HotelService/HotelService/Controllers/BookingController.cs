using HotelService.Services;
using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    [HttpGet("{reference}")]
    [ProducesResponseType<BookingDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBookingByReference([FromRoute]int reference, CancellationToken cancellationToken)
    {
        var booking = await bookingService.GetBookingByReferenceAsync(reference, cancellationToken);

        return Ok(booking);
    }

    [HttpPost("create")]
    [ProducesResponseType<BookingDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateRoomBooking([FromBody] CreateRoomBookingDto createRoomBookingDto, CancellationToken cancellationToken)
    {
        var booking = await bookingService.CreateRoomBooking(createRoomBookingDto, cancellationToken);

        return Ok(booking);
    }
}
