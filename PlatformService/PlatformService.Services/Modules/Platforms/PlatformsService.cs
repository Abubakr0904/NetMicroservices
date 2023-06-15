using PlatformService.Domain.Infrastructure;
using PlatformService.Domain.Modules.Platforms.Models;
using PlatformService.Domain.Modules.Platforms.Services;

namespace PlatformService.Services.Modules.Platforms;

public sealed class PlatformsService : IPlatformsService
{
    private readonly IUnitOfWork _unitOfWork;

    public PlatformsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Get all platforms.
    /// </summary>
    public Task<IPlatform[]> GetAllPlatformsAsync()
    {
        return _unitOfWork.Platforms.GetAllPlatformsAsync();
    }

    /// <summary>
    /// Get platform by id.
    /// </summary>
    /// <param name="id"></param>
    public Task<IPlatform> GetPlatformByIdAsync(int id)
    {
        return _unitOfWork.Platforms.GetPlatformByIdAsync(id);
    }

    /// <summary>
    /// Create platform.
    /// </summary>
    /// <param name="platform"></param>
    public async Task<bool> CreatePlatformAsync(IPlatformCreate platform)
    {
        await _unitOfWork.Platforms.CreatePlatformAsync(platform);

        return await _unitOfWork.TrySaveChangesAsync();
    }
}
