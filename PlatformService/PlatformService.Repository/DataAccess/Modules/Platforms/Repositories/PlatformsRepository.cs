using Microsoft.EntityFrameworkCore;
using PlatformService.Db.Data;
using PlatformService.Domain.Modules.Platforms.Models;
using PlatformService.Domain.Modules.Platforms.Repositories;
using PlatformService.Repository.DataAccess.Modules.Platforms.Models;

namespace PlatformService.Repository.DataAccess.Modules.Platforms.Repositories;

public sealed class PlatformsRepository : IPlatformsRepository
{
    private readonly AppDbContext _dbContext;

    public PlatformsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Get all platforms.
    /// </summary>
    public async Task<IPlatform[]> GetAllPlatformsAsync()
    {
        return await _dbContext.Platforms.AsNoTracking()
                                         .Select(p => new Platform
                                         {
                                             Id = p.Id,
                                             Name = p.Name,
                                             Publisher = p.Publisher,
                                             Cost = p.Cost
                                         })
                                         .ToArrayAsync();
    }

    /// <summary>
    /// Get platform by id.
    /// </summary>
    /// <param name="id"></param>
    public async Task<IPlatform> GetPlatformByIdAsync(int id)
    {
        return await _dbContext.Platforms.AsNoTracking()
                                         .Where(p => p.Id == id)
                                         .Select(p => new Platform
                                         {
                                             Id = p.Id,
                                             Name = p.Name,
                                             Publisher = p.Publisher,
                                             Cost = p.Cost
                                         })
                                         .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Create platform.
    /// </summary>
    /// <param name="platform"></param>
    public async Task CreatePlatformAsync(IPlatformCreate platform)
    {
        ArgumentNullException.ThrowIfNull(platform, nameof(platform));

        var newDbPlatform = new Db.Entities.Platform
        {
            Name = platform.Name,
            Publisher = platform.Publisher,
            Cost = platform.Cost
        };

        await _dbContext.Platforms.AddAsync(newDbPlatform);
    }
}
