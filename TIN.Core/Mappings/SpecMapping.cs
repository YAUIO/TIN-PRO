using System.Globalization;
using TIN.Core.Dtos;
using TIN.Core.Dtos.Localization;
using TIN.Core.Dtos.Product;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class SpecMapping
{
    public static GetSpecDto ToDto(this SpecModel model) => new()
    {
        Id = model.Id,
        Key = model.Names.Where(s => s.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLanguageEnum())
            .Select(s => s.Name)
            .FirstOrDefault(model.Names.First(s => s.Language == CultureInfo.DefaultThreadCurrentUICulture!.TwoLetterISOLanguageName.ToLanguageEnum()).Name),
        Value = model.Value,
    };

    public static SpecModel ToModel(this PostSpecDto dto, ProductModel product) => new()
    {
        Value = dto.Value,
        Product = product,
    };

    public static GetSpecNameDto ToDto(this SpecNameModel model) => new()
    {
        Language = model.Language,
        SpecId = model.Spec.Id,
        Name = model.Name,
    };
}