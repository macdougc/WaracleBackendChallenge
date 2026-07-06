using HotelService.Services;
using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/v1/booking")]
[ApiController]
public class BookingController(IBookingService bookingService) : ControllerBase
{
    /// <summary>
    /// Gets a booking matching the reference
    /// </summary>
    /// <param name="reference"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Booking</returns>
    [HttpGet("{reference}")]
    [ProducesResponseType<BookingDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBookingByReference([FromRoute]int reference, CancellationToken cancellationToken)
    {
        var booking = await bookingService.GetBookingByReferenceAsync(reference, cancellationToken);

        return Ok(booking);
    }

    /// <summary>
    /// Creates a booking if data is valid.
    /// </summary>
    /// <param name="createRoomBookingDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Created booking</returns>
    [HttpPost("create")]
    [ProducesResponseType<BookingDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRoomBooking([FromBody] CreateRoomBookingDto createRoomBookingDto, CancellationToken cancellationToken)
    {
        var booking = await bookingService.CreateRoomBooking(createRoomBookingDto, cancellationToken);

        return Ok(booking);
    }
}
