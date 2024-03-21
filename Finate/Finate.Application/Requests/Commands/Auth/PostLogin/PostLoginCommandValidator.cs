using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostLogin;

public class PostLoginCommandValidator : IValidator<PostLoginCommand>
{
    public List<string> Validate(PostLoginCommand request)
    {
        var result = new List<string>();
        
        if(string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if(string.IsNullOrWhiteSpace(request.Password))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Password)));

        return result;
    }
}