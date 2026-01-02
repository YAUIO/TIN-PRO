using TIN.Data.Entities.Enums;

namespace TIN.Core.Mappings;

public static class StringToLanguageMapping
{
    public static Language ToLanguageEnum(this string language) => language switch
    {
        "en" => Language.English,
        "pl" => Language.Polish,
        _ => Language.English,
    };
}