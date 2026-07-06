using HotelService.Services;
using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/v1/hotel")]
[ApiController]
public class HotelController(IHotelService hotelService) : ControllerBase
{
    [HttpGet("find-hotel/{name}")]
    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHotelByName([FromRoute]string name, CancellationToken cancellationToken)
    {
        var hotel = await hotelService.GetHotelByNameAsync(name, cancellationToken);

        return Ok(hotel);
    }

    [HttpPost("find-rooms")]
    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableRooms([FromBody] SearchAvailableRoomsDto searchAvailableRoomsDto, CancellationToken cancellationToken)
    {
        var rooms = await hotelService.GetAvailableRoomsAsync(searchAvailableRoomsDto, cancellationToken);

        return Ok(rooms);
    }
}
