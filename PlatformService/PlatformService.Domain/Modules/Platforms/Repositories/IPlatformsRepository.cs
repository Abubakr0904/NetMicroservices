using PlatformService.Domain.Modules.Platforms.Models;

namespace PlatformService.Domain.Modules.Platforms.Repositories;

public interface IPlatformsRepository
{
    /// <summary>
    /// Get all platforms.
    /// </summary>
    public Task<IPlatform[]> GetAllPlatformsAsync();

    /// <summary>
    /// Get platform by id.
    /// </summary>
    /// <param name="id"></param>
    public Task<IPlatform> GetPlatformByIdAsync(int id);

    /// <summary>
    /// Create platform.
    /// </summary>
    /// <param name="platform"></param>
    public Task CreatePlatformAsync(IPlatformCreate platform);
}
