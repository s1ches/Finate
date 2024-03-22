using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finate.Application.Requests.Commands.Auth.PostLogin;

public class PostLoginCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, 
    IValidator<PostLoginCommand> validator)
    : IRequestHandler<PostLoginCommand, PostLoginResponse>
{
    public async Task<PostLoginResponse> Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        var response = new PostLoginResponse {IsSuccessful = false};
        
        var errors = validator.Validate(request);

        if (errors.Count != 0)
        {
            response.ErrorMessages = errors;
            return response;
        }
        
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            response.ErrorMessages.Add(AuthErrorMessages.UserWithThisEmailNotFound);
            return response;
        }

        var signInResult = await signInManager.PasswordSignInAsync(user, request.Password,
            request.RememberMe, false);

        if (!signInResult.Succeeded)
        {
            response.ErrorMessages.Add(AuthErrorMessages.WrongPassword);
            return response;
        }

        response.IsSuccessful = true;
        return response;
    }
}