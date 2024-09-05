using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zarani.Application.Services;
using Zarani.Domain.BaseResponse;
using Zarani.Domain.Dtos;
using Zarani.Domain.Response;
using Zarani.Infrastructure.Models;
namespace Zarani.Api.Controllers
{
    /// <summary>
    /// Controller for managing user accounts.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController<AccountController>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign-in manager.</param>
        /// <param name="tokenService">The token service.</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="model">The registration details.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <param name="model">The login details.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var tokenResult = await _tokenService.CreateTokenByUser(HttpContext.User);
                var serviceResponse = new BaseResponse<LoginResponse>()
                {
                    Data = tokenResult
                };
                return Ok(serviceResponse);
            }
            return Unauthorized();
        }
    }
}

