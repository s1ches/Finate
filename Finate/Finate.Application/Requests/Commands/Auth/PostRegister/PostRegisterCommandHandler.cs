using Finate.Application.Constants;
using Finate.Application.Interfaces;
using Finate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Finate.Application.Requests.Commands.Auth.PostRegister;

public class PostRegisterCommandHandler(UserManager<User> userManager, IEmailSender emailSender,
    IValidator<PostRegisterCommand> validator)
    : IRequestHandler<PostRegisterCommand, PostRegisterResponse>
{
    public async Task<PostRegisterResponse> Handle(PostRegisterCommand request, CancellationToken cancellationToken)
    {
        var response = new PostRegisterResponse { IsSuccessful = false };

        var errors = validator.Validate(request);

        if (errors.Count != 0)
        {
            response.ErrorMessages = errors;
            return response;
        }
        
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is not null)
        {
            response.ErrorMessages.Add(AuthErrorMessages.UserWithSameEmailAlreadyExist);
            return response;
        }

        user = new User { Email = request.Email, UserName = request.UserName };

        var registerResult = await userManager.CreateAsync(user, request.Password);

        if (!registerResult.Succeeded)
        {
            response.ErrorMessages.AddRange(registerResult.Errors.Select(x => x.Description));
            return response;
        }

        await userManager.AddToRoleAsync(user, request.Role.ToUpper());
        
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        
        await emailSender.SendEmailAsync(user.Email, AuthEmailMessages.ConfirmEmailMessage(user.UserName, token), 
            cancellationToken);
        
        response.IsSuccessful = true;
        return response;
    }
}