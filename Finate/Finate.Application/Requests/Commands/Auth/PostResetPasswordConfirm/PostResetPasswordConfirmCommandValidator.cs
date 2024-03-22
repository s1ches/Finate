using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommandValidator : IValidator<PostResetPasswordConfirmCommand>
{
    public List<string> Validate(PostResetPasswordConfirmCommand request)
    {
        if (request is null)
            throw new NullReferenceException(nameof(request));
        
        var result = new List<string>();
        
        if(string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if(string.IsNullOrWhiteSpace(request.UserResetPasswordToken))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.UserResetPasswordToken)));

        if (string.IsNullOrWhiteSpace(request.NewPassword))
        {
            result.Add(AuthErrorMessages.EmptyField(nameof(request.NewPassword)));
            return result;
        }

        if(request.NewPassword.Length < 8)
            result.Add(AuthErrorMessages.InvalidPasswordLength);

        if (string.IsNullOrWhiteSpace(request.NewPasswordConfirm))
        {
            result.Add(AuthErrorMessages.EmptyField(nameof(request.NewPasswordConfirm)));
            return result;
        }

        if(!request.NewPassword.Equals(request.NewPasswordConfirm, StringComparison.OrdinalIgnoreCase))
            result.Add(AuthErrorMessages.PasswordIsNotConfirmed);

        return result;
    }
}