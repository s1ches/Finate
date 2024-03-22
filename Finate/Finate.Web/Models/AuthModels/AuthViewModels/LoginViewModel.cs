using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models.AuthModels.AuthViewModels;

/// <summary>
/// Модель для формы Sign In
/// </summary>
public class LoginViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}