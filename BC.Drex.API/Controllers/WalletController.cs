using System.Security.Claims;
using BC.Drex.API.Dtos.Wallet;
using Microsoft.AspNetCore.Mvc;
using BC.Drex.API.AppServices.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BC.Drex.API.Controllers
{
    /// <summary>
    /// Controller for managing wallet operations.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("v1/[controller]")]
    public class WalletController : ControllerBase
    {
        #region -> Constructor
        private readonly IWalletAppService _appservice;

        /// <summary>
        /// Initialize a new instance of the <see cref="WalletController"/> class.
        /// </summary>
        /// <param name="appservice"></param>
        public WalletController(IWalletAppService appservice)
        {
            _appservice = appservice;
        }
        #endregion

        #region -> Methods
        /// <summary>
        /// Create User Wallet
        /// </summary>
        /// <returns></returns>
        [HttpPost("create-wallet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateWalletAsync()
        {
            var result = await _appservice.PostCreateWalletAsync(User.FindFirstValue("UserId")!).ConfigureAwait(false);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Get user wallet
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-my-wallet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserWallet()
        {
            var result = await _appservice.GetWalletByUserIdAsync(User.FindFirstValue("UserId")!).ConfigureAwait(false);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Make transactions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("transfer-amount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTransferAsync([FromBody] WalletTransferRequest request)
        {
            request.FromUserId = Guid.Parse(User.FindFirstValue("UserId")!);
            var result = await _appservice.PostWalletTransferAmountAsync(request).ConfigureAwait(false);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }

        /// <summary>
        /// Add amount to logged user wallet
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("add-amount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAmountAsync([FromQuery] decimal amount)
        {
            var result = await _appservice.PostAddAmountAsync(amount, User.FindFirstValue("UserId")).ConfigureAwait(false);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        #endregion
    }
}

