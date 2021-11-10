using BookingApp.Classes;
using BookingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingApp.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var result = await _authService.SignIn(username, password);
            if (!result.IsSuccess)
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }

        [HttpPost("/SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserModel userModel)
        {
            var result = await _authService.SignUp(userModel);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
