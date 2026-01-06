using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class UsersController(IUserService users) : ControllerBase
{
    [Authorize(Policy = "Admin")]
    [HttpGet("{pageSize:int}/{page:int}")]
    public async Task<IActionResult> GetAllUsers([FromRoute] int page, [FromRoute] int pageSize)
    {
        return Ok(await users.GetAllUsersAsync(new()
        {
            Page = page,
            PageSize = pageSize,
        }));
    }
    
    [Authorize(Policy = "Admin")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id)
    {
        return Ok(await users.GetUserAsync(id));
    }
    
    [Authorize(Policy = "Admin")]
    [HttpPut("{id:guid}/admin")]
    public async Task<IActionResult> MakeAdminById([FromRoute] Guid id)
    {
        await users.MakeAdminById(id);
        return NoContent();
    }
}