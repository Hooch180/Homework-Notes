using Homework.Application.Common.Interfaces.Repositories;
using Homework.Infrastructure.Common.Persistence;
using Homework.Infrastructure.Notes.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Homework.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddPersistence();
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<HomeworkDbContext>(options =>
            options.UseInMemoryDatabase("HomeworkDb"));
        
        services.AddScoped<INotesRepository, NotesRepository>();
        
        return services;
    }
}