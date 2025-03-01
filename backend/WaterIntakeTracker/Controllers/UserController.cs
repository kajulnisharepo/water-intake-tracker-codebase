using Microsoft.AspNetCore.Mvc;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Datalayer.Models;
using WaterIntakeTracker.Services.Interface;
using System.Threading.Tasks;

namespace WaterIntakeTracker.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userModel">User information for registration</param>
        /// <returns>Result of the registration process</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegisterUserAsync(userModel);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Get user information by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User information</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        /// <summary>
        /// Get user's BMI information by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User's BMI information</returns>
        [HttpGet("{id}/bmi")]
        public async Task<IActionResult> GetUserBMI(int id)
        {
            var result = await _userService.GetUserBMIAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
