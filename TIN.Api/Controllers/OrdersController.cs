using Microsoft.AspNetCore.Mvc;
using TIN.Core.Dtos.Order;
using TIN.Core.Services;

namespace TIN_PRO.Controllers;

[ApiController]
[Route($"{ApiConstants.BaseApiUri}/[controller]")]
public class OrdersController(IOrderService orders) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        return Ok(await orders.GetAllOrdersAsync());
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