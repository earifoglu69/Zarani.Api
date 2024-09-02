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
    [ApiController]
       [Route("api/[controller]")]
       public class AccountController : BaseController<AccountController>
       {
           public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly ITokenService _tokenService;
           public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
           {
               _userManager = userManager;
               _signInManager = signInManager;
                _tokenService=tokenService;
           }

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
   
