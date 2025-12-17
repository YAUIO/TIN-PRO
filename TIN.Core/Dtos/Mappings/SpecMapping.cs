using TIN.Data.Entities;

namespace TIN.Core.Dtos.Mappings;

public static class SpecMapping
{
    public static GetSpecDto ToDto(this SpecModel model) => new()
    {
        Key = model.Key,
        Value = model.Value,
    };
}