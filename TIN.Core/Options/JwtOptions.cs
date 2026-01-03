namespace TIN_PRO.Options;

public class JwtOptions
{
    public string Key { get; init; }
    public int ExpirationInMinutes { get; init; }
}