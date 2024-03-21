using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommandValidator : IValidator<PostResetPasswordCommand>
{
    public List<string> Validate(PostResetPasswordCommand request)
    {
        var result = new List<string>();
        
        if (string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if (string.IsNullOrWhiteSpace(request.NewPassword))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.NewPassword)));
        
        if (string.IsNullOrWhiteSpace(request.NewPasswordConfirm))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.NewPasswordConfirm)));
        
        if(!request.NewPassword.Equals(request.NewPasswordConfirm, StringComparison.OrdinalIgnoreCase))
            result.Add(AuthErrorMessages.PasswordIsNotConfirmed);

        return result;
    }
}