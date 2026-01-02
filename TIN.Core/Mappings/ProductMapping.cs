using TIN.Core.Dtos;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class ProductMapping
{
    public static GetProductDto ToDto(this ProductModel model, Language language) => new()
    {
        Name = model.Name,
        Description = model.Descriptions
            .FirstOrDefault(s => s.Language == language)?.Description,
        ImageUri = model.ImageUri,
        Specs = [.. model.Specs.Select(s => s.ToDto(language))],
    };

    public static ProductModel ToModel(this PostProductDto dto) => new()
    {
        Name = dto.Name,
        ImageUri = dto.ImageUri,
    };
}