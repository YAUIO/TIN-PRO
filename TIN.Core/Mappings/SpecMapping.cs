using System.Globalization;
using TIN.Core.Dtos;
using TIN.Data.Entities;

namespace TIN.Core.Mappings;

public static class SpecMapping
{
    public static GetSpecDto ToDto(this SpecModel model) => new()
    {
        Key = model.Names.Where(s => s.Language == CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToLanguageEnum())
            .Select(s => s.Name)
            .FirstOrDefault(model.Names.First(s => s.Language == CultureInfo.DefaultThreadCurrentUICulture!.TwoLetterISOLanguageName.ToLanguageEnum()).Name),
        Value = model.Value,
    };
}