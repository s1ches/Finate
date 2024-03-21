namespace Finate.Web.Models.AuthModels.AuthViewModels;

public class ResetPasswordConfirmViewModel
{
    public string ReturnUrl { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string NewPassword { get; set; } = default!;
    
    public string UserResetPasswordToken { get; set; } = default!;
}