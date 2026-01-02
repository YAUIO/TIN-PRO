using TIN.Core.Dtos;
using TIN.Data.Entities;

namespace TIN.Core.Mappings;

public static class OrderItemMapping
{
    public static GetOrderItemDto ToDto(this OrderItemModel model) => new()
    {
        Quantity = model.Quantity,
        Product = model.Product.ToDto(),
    };

    public static OrderItemModel ToModel(this PostOrderItemDto dto, Guid orderId) => new()
    {
        OrderId = orderId,
        Quantity = dto.Quantity,
        ProductId = dto.ProductId,
    };
}