using Microsoft.Extensions.DependencyInjection;

namespace Homework.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));
            // TODO: Add validation behavior
        });
        
        // TODO: Register validators
        
        return services;
    }
}