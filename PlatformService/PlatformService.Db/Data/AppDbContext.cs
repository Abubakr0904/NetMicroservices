// Ignore Spelling: App

using Microsoft.EntityFrameworkCore;
using PlatformService.Db.Entities;

namespace PlatformService.Db.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// The platforms table.
    /// </summary>
    public DbSet<Platform> Platforms { get; set; }
}
