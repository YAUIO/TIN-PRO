using TIN.Core.Dtos;
using TIN.Data.Entities;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class SpecMapping
{
    public static GetSpecDto ToDto(this SpecModel model, Language language) => new()
    {
        Key = model.Names.Where(s => s.Language == language)
            .Select(s => s.Name)
            .FirstOrDefault(model.Names.First().Name),
        Value = model.Value,
    };
}