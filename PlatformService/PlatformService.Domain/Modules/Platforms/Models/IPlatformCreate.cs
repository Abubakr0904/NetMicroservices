namespace PlatformService.Domain.Modules.Platforms.Models;

public interface IPlatformCreate
{
    /// <summary>
    /// The name of the platform.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The publisher of the platform.
    /// </summary>
    public string Publisher { get; }

    /// <summary>
    /// The cost of the platform.
    /// </summary>
    public string Cost { get; }
}
