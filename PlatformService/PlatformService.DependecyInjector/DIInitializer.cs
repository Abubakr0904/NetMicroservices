using Microsoft.Extensions.DependencyInjection;
using PlatformService.Domain.Infrastructure;
using PlatformService.Domain.Modules.Platforms.Repositories;
using PlatformService.Domain.Modules.Platforms.Services;
using PlatformService.Repository.DataAccess.Modules.Platforms.Repositories;
using PlatformService.Repository.DataAccess.UnitOfWork;
using PlatformService.Services.Modules.Platforms;

namespace PlatformService.DependecyInjector;

public static class DIInitializer
{
    /// <summary>
    /// Initialize dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static void InitializeDependencies(this IServiceCollection services)
    {
        RegisterServices(services);
        RegisterRepositories(services);
        RegisterUnitOfWork(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IPlatformsService, PlatformsService>();
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