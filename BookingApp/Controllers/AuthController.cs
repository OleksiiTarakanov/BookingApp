using BookingApp.Classes;
using BookingApp.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        private readonly IValidator<UserModel> _validator;
        public AuthController(IAuthService authService, IValidator<UserModel> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost("/SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] Credentials credentials)
        {
            var result = await _authService.SignIn(credentials);
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
            var validationResult = await _validator.ValidateAsync(userModel);
            validationResult.AddToModelState(ModelState, null);
            if (ModelState.IsValid)
            {
                var result = await _authService.SignUp(userModel);
                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            return UnprocessableEntity(ModelState);
        }
    }
}
