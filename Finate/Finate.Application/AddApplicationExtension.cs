using Finate.Application.Interfaces;
using Finate.Application.Requests.Commands.Auth.GetConfirmEmail;
using Finate.Application.Requests.Commands.Auth.PostLogin;
using Finate.Application.Requests.Commands.Auth.PostRegister;
using Finate.Application.Requests.Commands.Auth.PostResetPassword;
using Finate.Application.Requests.Commands.Auth.PostResetPasswordConfirm;
using Microsoft.Extensions.DependencyInjection;

namespace Finate.Application;

public static class AddApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AddApplicationExtension).Assembly));

        services.AddTransient<IValidator<PostLoginCommand>, PostLoginCommandValidator>();
        services.AddTransient<IValidator<PostRegisterCommand>, PostRegisterCommandValidator>();
        services.AddTransient<IValidator<GetConfirmEmailCommand>, GetConfirmEmailCommandValidator>();
        services.AddTransient<IValidator<PostResetPasswordCommand>, PostResetPasswordCommandValidator>();
        services.AddTransient<IValidator<PostResetPasswordConfirmCommand>, PostResetPasswordConfirmCommandValidator>();
        
        return services;
    }
}