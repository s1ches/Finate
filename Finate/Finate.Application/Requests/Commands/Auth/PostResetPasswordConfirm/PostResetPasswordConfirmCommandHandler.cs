using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;

public class PostResetPasswordConfirmCommandHandler(UserManager<User> userManager, 
    IValidator<PostResetPasswordConfirmCommand> validator) :
    IRequestHandler<PostResetPasswordConfirmCommand, PostResetPasswordConfirmResponse>
{
    public async Task<PostResetPasswordConfirmResponse> Handle(PostResetPasswordConfirmCommand request, CancellationToken cancellationToken)
    {
        var response = new PostResetPasswordConfirmResponse { IsSuccessful = false };
        
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
        
        var resetPasswordResult =
            await userManager.ResetPasswordAsync(user, request.UserResetPasswordToken, request.NewPassword);
        
        if (!resetPasswordResult.Succeeded)
        {
            response.ErrorMessages.AddRange(resetPasswordResult.Errors.Select(x => x.Description));
            return response;
        }

        response.IsSuccessful = true;
        return response;
    }
}