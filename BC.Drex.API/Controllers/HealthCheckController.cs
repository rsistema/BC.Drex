using Microsoft.AspNetCore.Mvc;
using BC.Drex.API.AppServices.Interfaces;

namespace BC.Drex.API.Controllers
{
    /// <summary>
    /// Controller for managing health check operations
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        #region -> Constructor
        private readonly IHealthCheckAppService _appService;

        /// <summary>
        /// Initialize a new instance of the <see cref="HealthCheckController"/> class
        /// </summary>
        /// <param name="appService"></param>
        public HealthCheckController(IHealthCheckAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region -> Methods
        /// <summary>
        /// Get health check status
        /// </summary>
        /// <returns></returns>
        [HttpGet("db-health")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAsync()
        {
            var isHealthy = await _appService.CheckHealthAsync();
            if (isHealthy)
                return NoContent();
            return BadRequest();
        }
        #endregion
    }
}
