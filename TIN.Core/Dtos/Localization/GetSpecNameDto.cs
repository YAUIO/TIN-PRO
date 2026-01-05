using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.Localization;

public class GetSpecNameDto
{
    public Guid SpecId { get; init; }
    
    public Language Language { get; init; }
    
    public string Name { get; init; }
}