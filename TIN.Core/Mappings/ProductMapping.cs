using System.Globalization;
using TIN.Core.Dtos;
using TIN.Data.Entities;

namespace TIN.Core.Mappings;

public static class ProductMapping
{
    public static GetProductDto ToDto(this ProductModel model) => new()
    {
        ProductId = model.Id,
        Name = model.Name,
        Description = model.Descriptions
            .FirstOrDefault(s => s.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLanguageEnum())?.Description,
        ImageUri = model.ImageUri,
        Price = model.Price,
        Specs = [.. model.Specs.Select(s => s.ToDto())],
    };

    public static ProductModel ToModel(this PostProductDto dto) => new()
    {
        Name = dto.Name,
        ImageUri = dto.ImageUri,
        Price = dto.Price,
    };
    
    public static ProductModel UpdateWithDto(this ProductModel model, PutProductDto dto)
    {
        if (dto.ProductId != model.Id)
            throw new ArgumentException("ProductId does not match");
        
        model.Name = dto.Name;
        model.ImageUri = dto.ImageUri;
        model.Price = dto.Price;
        
        return model;
    }
}