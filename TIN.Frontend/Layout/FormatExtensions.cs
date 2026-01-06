namespace TIN.Frontend.Layout;

public static class FormatExtensions
{
    public static string ToErrorString(this HttpRequestException e) => $"{e.StatusCode}";
}