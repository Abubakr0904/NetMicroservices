using Microsoft.Extensions.DependencyInjection;
using PlatformService.Domain.Infrastructure;
using PlatformService.Domain.Modules.Platforms.Repositories;
using PlatformService.Repository.DataAccess.Modules.Platforms.Repositories;
using PlatformService.Repository.DataAccess.UnitOfWork;

namespace PlatformService.DependecyInjector;

public static class DIInitializer
{
    /// <summary>
    /// Initialize dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static void InitializeDependencies(this IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterUnitOfWork(services);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IPlatformsRepository, PlatformsRepository>();
    }

    private static void RegisterUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}