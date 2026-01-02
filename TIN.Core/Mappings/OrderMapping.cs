using TIN.Core.Dtos;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class OrderMapping
{
    public static GetOrderDto ToDto(this OrderModel model, Language language) => new()
    {
        Id = model.Id,
        OrderDate = model.CreatedAt,
        CompletionDate = model.CompletedAt,
        OrderStatus = model.Status,
        Customer = model.Customer.ToDto(language),
        Products = [.. model.Items.Select(s => s.ToDto(language))],
    };
}