using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models.AuthModels.AuthViewModels;

/// <summary>
/// Модель для подтверждения сброса пароля
/// </summary>
public class ResetPasswordConfirmViewModel
{
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Токен подтверждения сброса пароля
    /// </summary>
    [Required]
    public string UserResetPasswordToken { get; set; } = default!;

    /// <summary>
    /// Новый пароль
    /// </summary>
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPassword { get; set; } = default!;
    
    /// <summary>
    /// Подтверждение нового пароля
    /// </summary>
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPasswordConfirm { get; set; } = default!;
}