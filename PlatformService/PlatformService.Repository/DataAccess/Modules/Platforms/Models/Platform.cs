using PlatformService.Domain.Modules.Platforms.Models;

namespace PlatformService.Repository.DataAccess.Modules.Platforms.Models;

internal sealed class Platform : IPlatform
{
    /// <summary>
    /// The id of the platform.
    /// </summary>
    public required int Id { get; internal set; }

    /// <summary>
    /// The name of the platform.
    /// </summary>
    public required string Name { get; internal set; }

    /// <summary>
    /// The publisher of the platform.
    /// </summary>
    public required string Publisher { get; internal set; }

    /// <summary>
    /// The cost of the platform.
    /// </summary>
    public required string Cost { get; internal set; }
}
