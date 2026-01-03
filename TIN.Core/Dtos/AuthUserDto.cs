using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos;

public class AuthUserDto
{
    public const int MinUserNameLength = 4;
    public const int MaxUserNameLength = 12;
    
    public const int MinPasswordLength = 8;
    public const int MaxPasswordLength = 16;
    
    [Required]
    [Length(MinUserNameLength, MaxUserNameLength)]
    public string UserName { get; init; }
    
    [Required]
    [Length(MinPasswordLength, MaxPasswordLength)]
    public string Password { get; init; }
}