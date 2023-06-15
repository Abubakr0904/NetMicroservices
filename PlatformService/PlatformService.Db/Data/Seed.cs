using Microsoft.Extensions.DependencyInjection;
using PlatformService.Db.Entities;

namespace PlatformService.Db.Data
{
    public static class Seed
    {
        /// <summary>
        /// Seed the database with data.
        /// </summary>
        /// <param name="dbContext"></param>
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.Platforms.Any())
            {
                return;
            }

            var platforms = GetPlatforms();
            await dbContext.AddRangeAsync(platforms);
            await dbContext.SaveChangesAsync();
        }

        private static IEnumerable<Platform> GetPlatforms()
        {
            return new List<Platform>
            {
                new Platform
                {
                    Name = "Dot Net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform
                {
                    Name = "SQL Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform
                {
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "Free"
                }
            };
        }
    }
}
