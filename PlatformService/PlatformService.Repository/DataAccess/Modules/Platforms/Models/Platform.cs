using PlatformService.Domain.Modules.Platforms.Models;

namespace PlatformService.Repository.DataAccess.Modules.Platforms.Models;

internal sealed class Platform : IPlatform
{
    /// <summary>
    /// The id of the platform.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// The name of the platform.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// The publisher of the platform.
    /// </summary>
    public required string Publisher { get; init; }

    /// <summary>
    /// The cost of the platform.
    /// </summary>
    public required string Cost { get; init; }
}
