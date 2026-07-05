using HotelService.Services;
using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController(IHotelService hotelService) : ControllerBase
{
    [HttpGet("{name}")]
    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHotelByName([FromRoute]string name, CancellationToken cancellationToken)
    {
        var hotel = await hotelService.GetHotelByNameAsync(name, cancellationToken);

        return Ok(hotel);
    }
}
