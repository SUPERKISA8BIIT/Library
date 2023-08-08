using Library.BLL.DTOs.AuthDto;
using Library.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {          
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AddUserDto user)
        {
            await _authService.Register(user);

            return Ok();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto user)
        {
            var token =  await _authService.SignIn(user);

            return Ok(token);
        }
    }
}
