using System.ComponentModel.DataAnnotations;
using TIN.Core.Exceptions;

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
        if (dto != null && (dto.Page < 1 || dto.PageSize < 1))
        {
            throw new BadRequestException();
        }
        return dto == null ? src : src.Skip(dto.PageSize * (dto.Page - 1)).Take(dto.PageSize);
    }
}