using TIN.Data.Entities;

namespace TIN.Core.Dtos.Mappings;

public static class ProductMapping
{
    public static GetProductDto ToDto(this ProductModel model) => new()
    {
        Name = model.Name,
        Description = model.Description,
        ImageUri = model.ImageUri,
        Specs = [.. model.Specs.Select(s => s.ToDto())],
    };
}