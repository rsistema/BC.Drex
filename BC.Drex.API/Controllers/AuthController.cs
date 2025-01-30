using BC.Drex.API.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;
using BC.Drex.API.AppServices.Interfaces;

namespace BC.Drex.API.Controllers
{
    /// <summary>
    /// Controller for managing authorization operations.
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        #region -> Constructor
        private readonly IAuthAppService _appservice;

        /// <summary>
        /// Initialize a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="appservice"></param>
        public AuthController(IAuthAppService appService)
        {
            _appservice = appService;
        }
        #endregion

        #region -> Methods
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _appservice.RegisterAsync(request).ConfigureAwait(false);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Bearer token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var token = await _appservice.LoginAsync(request);
            return !string.IsNullOrEmpty(token)
                ? Ok(new { Token = token })
                : BadRequest();
        }
        #endregion
    }
}
