namespace Notes.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddExceptionHandlers();
        services.AddProblemDetails();
        
        return services;
    }
}