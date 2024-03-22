using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finate.Application.Requests.Commands.Auth.PostResetPassword;

public class PostResetPasswordCommandHandler(UserManager<User> userManager,
    IEmailSender emailSender,
    IValidator<PostResetPasswordCommand> validator)
    : IRequestHandler<PostResetPasswordCommand, PostResetPasswordResponse>
{
    public async Task<PostResetPasswordResponse> Handle(PostResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var response = new PostResetPasswordResponse { IsSuccessful = false };
        
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
        
        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var confirmLink = BaseUrls.ConfirmPasswordResetLink(token, user.Email!);
        
        await emailSender.SendEmailAsync(user.Email!,
            AuthEmailMessages.ResetPasswordConfirmMessage(user.UserName!, confirmLink), cancellationToken);

        response.IsSuccessful = true;
        return response;
    }
}