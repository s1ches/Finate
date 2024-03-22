using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommandValidator : IValidator<GetConfirmEmailCommand>
{
    public List<string> Validate(GetConfirmEmailCommand request)
    {
        if (request is null)
            throw new NullReferenceException(nameof(request));
        
        var result = new List<string>();
        
        if(string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if(string.IsNullOrWhiteSpace(request.UserConfirmEmailToken))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.UserConfirmEmailToken)));

        return result;
    }
}