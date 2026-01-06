using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos.Order;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class OrdersController(IOrderService orders) : ControllerBase
{
    [HttpGet("{pageSize:int}/{page:int}")]
    public async Task<IActionResult> GetAllOrders([FromRoute] int page, [FromRoute] int pageSize)
    {
        return Ok(await orders.GetAllOrdersAsync(new()
        {
            Page = page,
            PageSize = pageSize,
        }));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder([FromRoute] Guid id)
    {
        return Ok(await orders.GetOrderAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] PostOrderDto dto)
    {
        return Ok(await orders.AddOrderAsync(dto));
    }
}