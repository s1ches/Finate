using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models.AuthModels.AuthViewModels;

/// <summary>
/// Модель для подтверждения сброса пароля
/// </summary>
public class ResetPasswordConfirmViewModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Required]
    public string UserResetPasswordToken { get; set; } = default!;

    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPassword { get; set; } = default!;
    
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPasswordConfirm { get; set; } = default!;
}