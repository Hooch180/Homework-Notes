namespace Notes.Api.Middleware.ExceptionHandlers;

public static class ExceptionHandlersExtensions
{
    public static IServiceProvider AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<CommandValidationExceptionHandler>();
        services.AddExceptionHandler<ApplicationExceptionHandler>();
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        
        return services.BuildServiceProvider();
    }
}