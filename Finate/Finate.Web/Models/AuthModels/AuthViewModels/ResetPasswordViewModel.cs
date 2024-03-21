using System.ComponentModel.DataAnnotations;

namespace Finate.Web.Models.AuthModels.AuthViewModels;

public class ResetPasswordViewModel
{
    public string ReturnUrl { get; set; } = string.Empty;

    [Microsoft.Build.Framework.Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPassword { get; set; } = default!;

    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPasswordConfirm { get; set; } = default!;
}