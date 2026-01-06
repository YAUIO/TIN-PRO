using System.ComponentModel.DataAnnotations;

namespace TIN.Core.Dtos.User;

public class RegisterUserDto
{
    [Required]
    [Length(AuthUserDto.MinUserNameLength, AuthUserDto.MaxUserNameLength)]
    public string UserName { get; set; }
    
    [Required]
    [Length(AuthUserDto.MinPasswordLength, AuthUserDto.MaxPasswordLength)]
    public string Password { get; set; }
    
    [Required]
    [Length(AuthUserDto.MinPasswordLength, AuthUserDto.MaxPasswordLength)]
    public string PasswordRepeat { get; set; }
}