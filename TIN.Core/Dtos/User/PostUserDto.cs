using System.ComponentModel.DataAnnotations;
using TIN.Data.Entities.Enums;

namespace TIN.Core.Dtos.User;

public class PostUserDto
{
    [Length(AuthUserDto.MinUserNameLength, AuthUserDto.MaxUserNameLength)]
    public string UserName { get; init; }
    
    [Length(AuthUserDto.MinPasswordLength, AuthUserDto.MaxPasswordLength)]
    public string Password { get; init; }
    
    public UserRole UserRole { get; init; }
}