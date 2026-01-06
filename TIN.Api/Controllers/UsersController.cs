using Microsoft.AspNetCore.Mvc;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class UsersController(IUserService users) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await users.GetAllUsersAsync());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        return Ok(await users.GetUserAsync(id));
    }
    
    [HttpPut("{id:guid}/admin")]
    public async Task<IActionResult> MakeAdminById([FromRoute] Guid id)
    {
        await users.MakeAdminById(id);
        return NoContent();
    }
}