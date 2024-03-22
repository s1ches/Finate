using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommandValidator : IValidator<PostResetPasswordCommand>
{
    public List<string> Validate(PostResetPasswordCommand request)
    {
        if (request is null)
            throw new NullReferenceException(nameof(request));
        
        var result = new List<string>();
        
        if (string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));

        return result;
    }
}