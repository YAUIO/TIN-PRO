using TIN.Core.Dtos;
using TIN.Core.Dtos.Order;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class OrderMapping
{
    public static GetOrderDto ToDto(this OrderModel model) => new()
    {
        Id = model.Id,
        OrderDate = model.CreatedAt,
        CompletionDate = model.CompletedAt,
        OrderStatus = model.Status,
        Customer = model.Customer.ToDtoWithoutOrders(),
        Products = [.. model.Items.Select(s => s.ToDto())],
    };

    public static OrderModel ToModel(this PostOrderDto dto) => new()
    {
        CreatedAt = dto.OrderDate,
        CompletedAt = dto.CompletionDate,
        Status = dto.OrderStatus ?? OrderStatus.Created,
    };

    public static OrderModel UpdateWithDto(this OrderModel model, PutOrderDto dto)
    {
        if (dto.Id != model.Id)
            throw new ArgumentException("Order id does not match");
        
        model.CreatedAt = dto.OrderDate;
        model.CompletedAt = dto.CompletionDate;
        model.Status = dto.OrderStatus;
        return model;
    }
}