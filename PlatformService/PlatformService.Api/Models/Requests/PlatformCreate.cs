using PlatformService.Api.Attributes;
using PlatformService.Domain.Modules.Platforms.Models;

namespace PlatformService.Api.Models.Requests
{
    public class PlatformCreate : IPlatformCreate
    {
        /// <summary>
        /// The name of the platform.
        /// </summary>
        [RequiredStringNotEmptyAndWhiteSpace]
        public string Name { get; set; } = default!;

        /// <summary>
        /// The publisher of the platform.
        /// </summary>
        [RequiredStringNotEmptyAndWhiteSpace]
        public string Publisher { get; set; } = default!;

        /// <summary>
        /// The cost of the platform.
        /// </summary>
        [RequiredStringNotEmptyAndWhiteSpace]
        public string Cost { get; set; } = default!;
    }
}
