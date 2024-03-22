using Finate.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Finate.Services;

public static class AddServicesExtension
{
    /// <summary>
    /// Добавление слоя сервисов
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IEmailSender, EmailSender.EmailSender>();
}