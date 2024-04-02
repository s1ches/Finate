using Microsoft.Extensions.DependencyInjection;

namespace Finate.Application;

public static class AddApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AddApplicationExtension).Assembly));
        
        return services;
    }
}