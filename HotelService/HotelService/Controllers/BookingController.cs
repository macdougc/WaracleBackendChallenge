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
    public async Task<IActionResult> GetBookingByReference([FromRoute]int reference)
    {
        var booking = await bookingService.GetBookingByReferenceAsync(reference);

        return Ok(booking);
    }
}
