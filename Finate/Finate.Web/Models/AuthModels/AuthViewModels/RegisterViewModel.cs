using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models.AuthModels.AuthViewModels;

/// <summary>
/// Модель для формы регистрации
/// </summary>
public class RegisterViewModel
{
    [Required]
    public string Role { get; set; } = string.Empty;

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string PasswordConfirm { get; set; } = string.Empty;
}