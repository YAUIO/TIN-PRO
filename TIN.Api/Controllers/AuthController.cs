using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos.User;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class AuthController(IUserService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthUserDto dto)
    {
        var token = await service.LoginUserAsync(dto);
        return Ok(new { token });
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        await service.AddUserAsync(dto);
        return NoContent();
    }
}