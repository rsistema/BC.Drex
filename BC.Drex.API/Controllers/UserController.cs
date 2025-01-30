using BC.Drex.API.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using BC.Drex.API.AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BC.Drex.API.Controllers
{
    /// <summary>
    /// Controller for managing users operations
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        #region -> Constructor
        private readonly IUserAppService _appService;

        /// <summary>
        /// Initialize a new instance of the <see cref="UserController"/> class
        /// </summary>
        /// <param name="appService"></param>
        public UserController(IUserAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region -> Methods
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
        {
            var result = await _appService.GetUserByIdAsync(id);
            return result.Success 
                ? Ok(result.Data) 
                : NotFound();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _appService.GetAllUsersAsync();
            return result.Success 
                ? Ok(result) 
                : NoContent();
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserRequest request)
        {
            var result = await _appService.UpdateUserAsync(request);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);   
        }
        #endregion
    }
}