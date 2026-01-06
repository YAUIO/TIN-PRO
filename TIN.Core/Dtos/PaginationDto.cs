using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos;

public class PaginationDto
{
    [Range(1, int.MaxValue)] public int Page { get; set; } = 1;

    [Range(1, int.MaxValue)] public int PageSize { get; set; } = int.MaxValue;
}

public static class PaginationExtensions
{
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> src, PaginationDto? dto)
    {
        return dto == null ? src : src.Skip(dto.PageSize * (dto.Page - 1)).Take(dto.PageSize);
    }
}