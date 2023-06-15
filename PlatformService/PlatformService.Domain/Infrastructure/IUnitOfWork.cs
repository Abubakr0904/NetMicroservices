using PlatformService.Domain.Modules.Platforms.Repositories;

namespace PlatformService.Domain.Infrastructure;

public interface IUnitOfWork
{
    /// <summary>
    /// The platforms repository.
    /// </summary>
    public IPlatformsRepository Platforms { get; }

    /// <summary>
    /// Try to save changes. Rollback if failed.
    /// </summary>
    /// <returns>true if successfully saved, false otherwise.</returns>
    public Task<bool> TrySaveChangesAsync();
}
