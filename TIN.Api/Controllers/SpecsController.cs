using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos.Product;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class SpecsController(ISpecService specs) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAllSpecs([FromBody] List<PostSpecDto> dtos)
    {
        return Ok(await specs.CreateAllSpecsAsync(dtos));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSpecs([FromBody] PutSpecsDto dto)
    {
        await specs.UpdateAllSpecsAsync(dto);
        return NoContent();
    }
}