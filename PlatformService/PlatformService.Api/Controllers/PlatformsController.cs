using Microsoft.AspNetCore.Mvc;
using PlatformService.Api.Attributes;
using PlatformService.Api.Models.Requests;
using PlatformService.Domain.Modules.Platforms.Services;

namespace PlatformService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public sealed class PlatformsController : ControllerBase
    {
        private readonly IPlatformsService _platformsService;

        public PlatformsController(IPlatformsService platformsService)
        {
            _platformsService = platformsService;
        }

        /// <summary>
        /// Get all platforms.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllPlatformsAsync()
        {
            var platforms = await _platformsService.GetAllPlatformsAsync();

            return Ok(platforms);
        }

        /// <summary>
        /// Get platform by id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformByIdAsync(int id)
        {
            var platform = await _platformsService.GetPlatformByIdAsync(id);

            return platform is null ? NotFound() : Ok(platform);
        }

        /// <summary>
        /// Create platform.
        /// </summary>
        /// <param name="platform"></param>
        [HttpPost]
        public async Task<IActionResult> CreatePlatformAsync([FromBody] PlatformCreate platform)
        {
            var result = await _platformsService.CreatePlatformAsync(platform);

            return result ? Ok() : BadRequest();
        }
    }
}
