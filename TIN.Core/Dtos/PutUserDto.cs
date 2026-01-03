using System.ComponentModel.DataAnnotations;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos;

public class PutUserDto
{
    [Required]
    public Guid UserId { get; init; }
    
    [Required]
    [Length(AuthUserDto.MinUserNameLength, AuthUserDto.MaxUserNameLength)]
    public string UserName { get; init; }
    
    [Required]
    public UserRole UserRole { get; init; }

    [Required]
    public ICollection<Guid> Orders { get; init; } = [];
}