using Microsoft.AspNetCore.Mvc;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Services.Interface;
using System.Threading.Tasks;

namespace WaterIntakeTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="loginModel">Login credentials</param>
        /// <returns>Authentication result with JWT token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.LoginAsync(loginModel);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Unauthorized(result);
        }
    }
}
