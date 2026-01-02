using TIN.Core.Dtos;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class OrderItemMapping
{
    public static GetOrderItemDto ToDto(this OrderItemModel model, Language language) => new()
    {
        Quantity = model.Quantity,
        Product = model.Product.ToDto(language),
    };

    public static OrderItemModel ToModel(this PostOrderItemDto dto) => new()
    {
        Quantity = dto.Quantity,
        ProductId = dto.ProductId,
    };
}