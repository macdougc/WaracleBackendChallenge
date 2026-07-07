using HotelService.Services;
using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/v1/hotel")]
[ApiController]
public class HotelController(IHotelService hotelService) : ControllerBase
{
    /// <summary>
    /// Find hotel by name
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Hotel</returns>
    [HttpGet("find-hotel/{name}")]
    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHotelByName([FromRoute]string name, CancellationToken cancellationToken)
    {
        var hotel = await hotelService.GetHotelByNameAsync(name, cancellationToken);

        return Ok(hotel);
    }

    /// <summary>
    /// Find available rooms
    /// </summary>
    /// <param name="searchAvailableRoomsDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Rooms</returns>
    [HttpPost("find-rooms")]
    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableRooms([FromBody] SearchAvailableRoomsDto searchAvailableRoomsDto, CancellationToken cancellationToken)
    {
        var rooms = await hotelService.GetAvailableRoomsAsync(searchAvailableRoomsDto, cancellationToken);

        return Ok(rooms);
    }

    [HttpPost("create-seeding-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateSeedingData(CancellationToken cancellationToken)
    {
        await hotelService.CreateSeedingData(cancellationToken);
        return Ok();
    }

    [HttpPost("remove-all-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RemoveAllData(CancellationToken cancellationToken)
    {
        await hotelService.RemoveAllData(cancellationToken);
        return Ok();
    }
}
