using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models;

public class RegisterViewModel
{
    public string ReturnUrl { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string PasswordConfirm { get; set; } = default!;
}