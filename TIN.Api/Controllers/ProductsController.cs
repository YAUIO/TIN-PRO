using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos.Product;
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
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        return Ok(await service.GetProductAsync(id));
    }

    [HttpDelete("{id:guid}")]
    public async Task RemoveProduct([FromRoute] Guid id)
    {
        await service.DeleteProductAsync(id);
    }
    
    [HttpPut]
    public async Task UpdateProduct([FromBody] PutProductWrapperDto dto)
    {
        await service.UpdateProductAsync(dto);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] PostProductWrapperDto dto)
    {
        var id = await service.AddProductAsync(dto);
        
        return Ok(id);
    }
}