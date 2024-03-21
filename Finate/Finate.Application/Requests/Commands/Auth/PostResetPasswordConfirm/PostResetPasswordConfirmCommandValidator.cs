using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommandValidator : IValidator<PostResetPasswordConfirmCommand>
{
    public List<string> Validate(PostResetPasswordConfirmCommand request)
    {
        var result = new List<string>();
        
        if(string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if(string.IsNullOrWhiteSpace(request.UserResetPasswordToken))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.UserResetPasswordToken)));

        return result;
    }
}