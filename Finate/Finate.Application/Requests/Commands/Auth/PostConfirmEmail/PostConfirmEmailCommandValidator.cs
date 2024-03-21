using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostConfirmEmail;

public class PostConfirmEmailCommandValidator : IValidator<PostConfirmEmailCommand>
{
    public List<string> Validate(PostConfirmEmailCommand request)
    {
        var result = new List<string>();
        
        if(string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if(string.IsNullOrWhiteSpace(request.UserConfirmEmailToken))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.UserConfirmEmailToken)));

        return result;
    }
}