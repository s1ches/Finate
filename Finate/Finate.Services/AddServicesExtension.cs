using Finate.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Finate.Services;

public static class AddServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IEmailSender, EmailSender.EmailSender>();
}