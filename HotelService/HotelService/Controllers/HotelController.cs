using HotelService.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{

    [ProducesResponseType<HotelDto>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHotelByName(string name)
    {
        // Implement logic to retrieve hotel by name
        return Ok();
    }
}
