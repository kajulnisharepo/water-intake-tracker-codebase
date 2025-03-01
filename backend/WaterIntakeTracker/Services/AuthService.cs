using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WaterIntakeTracker.DataLayer;
using WaterIntakeTracker.Datalayer.Models;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Services.Interface;

namespace WaterIntakeTracker.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ApiResponse<string>> LoginAsync(LoginModel loginModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => 
                u.Username == loginModel.UsernameOrEmail || u.Email == loginModel.UsernameOrEmail);

            if (user == null || !VerifyPassword(loginModel.Password, user.Password))
            {
                return new ApiResponse<string>
                {
                    Code = "401",
                    Message = "Invalid username/email or password",
                    ResponseType = ApiResponseType.Failure
                };
            }

            var token = GenerateSimpleToken(user);

            return new ApiResponse<string>
            {
                Code = "200",
                Message = "Login successful",
                Data = token,
                ResponseType = ApiResponseType.Success
            };
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            var parts = storedPassword.Split(':');
            if (parts.Length != 2)
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[0]);
            var hashedPassword = parts[1];

            string hashed = Convert.ToBase64String(Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(
                password: inputPassword,
                salt: salt,
                prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword == hashed;
        }

        private string GenerateSimpleToken(User user)
        {
            // This is a simple token generation method.
            // In a production environment, you should use a proper JWT implementation.
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{user.Id}:{user.Email}:{Guid.NewGuid()}"));
        }
    }
}
