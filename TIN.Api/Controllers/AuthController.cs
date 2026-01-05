using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos;
using TIN.Core.Dtos.User;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/auth")]
public class AuthController(UserService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthUserDto dto)
    {
        var token = await service.LoginUserAsync(dto);
        return Ok(new { token });
    }
}