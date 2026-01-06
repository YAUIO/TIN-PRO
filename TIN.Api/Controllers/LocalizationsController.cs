using Microsoft.AspNetCore.Mvc;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class LocalizationsController(ILocalizationService localizations) : ControllerBase
{
    [HttpGet("specnames/{productId:guid}")]
    public async Task<IActionResult> GetSpecNames([FromRoute] Guid productId)
    {
        return Ok(await localizations.GetSpecNamesAsync(productId));
    } 
    
    [HttpGet("descriptions/{productId:guid}")]
    public async Task<IActionResult> GetDescriptions([FromRoute] Guid productId)
    {
        return Ok(await localizations.GetDescriptionsAsync(productId));
    } 
}