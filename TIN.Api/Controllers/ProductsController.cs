using Microsoft.AspNetCore.Mvc;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class ProductsController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await service.GetAllProductsAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        return Ok(await service.GetProductAsync(id));
    }
}