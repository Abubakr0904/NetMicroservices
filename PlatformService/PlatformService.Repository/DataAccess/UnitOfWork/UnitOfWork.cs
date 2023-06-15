using PlatformService.Db.Data;
using PlatformService.Domain.Infrastructure;
using PlatformService.Domain.Modules.Platforms.Repositories;

namespace PlatformService.Repository.DataAccess.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext,
                      IPlatformsRepository platformsRepository)
    {
        _dbContext = dbContext;
        Platforms = platformsRepository;
    }

    /// <summary>
    /// The platforms repository.
    /// </summary>
    public IPlatformsRepository Platforms { get; }

    /// <summary>
    ///Try to save changes. Rollback if failed.
    /// </summary>
    public async Task<bool> TrySaveChangesAsync()
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            return false;
        }

        return true;
    }
}
