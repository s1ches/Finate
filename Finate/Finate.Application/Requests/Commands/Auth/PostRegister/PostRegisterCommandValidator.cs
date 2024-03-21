using Finate.Application.Constants;
using Finate.Application.Interfaces;

namespace Finate.Application.Requests.Commands.Auth.PostRegister;

public class PostRegisterCommandValidator : IValidator<PostRegisterCommand>
{
    public List<string> Validate(PostRegisterCommand request)
    {
        var result = new List<string>();
        
        if (string.IsNullOrWhiteSpace(request.UserName))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.UserName)));
        
        if (string.IsNullOrWhiteSpace(request.Email))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Email)));
        
        if (string.IsNullOrWhiteSpace(request.Password))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Password)));
        
        if (string.IsNullOrWhiteSpace(request.PasswordConfirm))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.PasswordConfirm)));
        
        if(string.IsNullOrWhiteSpace(request.Role))
            result.Add(AuthErrorMessages.EmptyField(nameof(request.Role)));
        
        if(!request.Password.Equals(request.PasswordConfirm, StringComparison.OrdinalIgnoreCase))
            result.Add(AuthErrorMessages.PasswordIsNotConfirmed);

        return result;
    }
}