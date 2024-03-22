using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finate.Application.Requests.Commands.Auth.GetConfirmEmail;

public class GetConfirmEmailCommandHandler(UserManager<User> userManager,
    SignInManager<User> signInManager,
    IValidator<GetConfirmEmailCommand> validator)
    : IRequestHandler<GetConfirmEmailCommand, GetConfirmEmailResponse>
{
    public async Task<GetConfirmEmailResponse> Handle(GetConfirmEmailCommand request,
        CancellationToken cancellationToken)
    {
        var response = new GetConfirmEmailResponse { IsSuccessful = false };
        
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

        var confirmEmailResult = await userManager.ConfirmEmailAsync(user, request.UserConfirmEmailToken);

        if (!confirmEmailResult.Succeeded)
        {
            response.ErrorMessages.AddRange(confirmEmailResult.Errors.Select(x => x.Description));
            return response;
        }
        
        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);
        await signInManager.SignInAsync(user, false);
        
        response.IsSuccessful = true;
        return response;
    }
}