using System.ComponentModel.DataAnnotations;

namespace PlatformService.Db.Entities;

public class Platform
{
    /// <summary>
    /// The primary key. Id of the platform
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// The name of the platform
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// The publisher of the platform
    /// </summary>
    [Required]
    public string Publisher { get; set; }

    /// <summary>
    /// The cost of the platform
    /// </summary>
    [Required]
    public string Cost { get; set; }
}
