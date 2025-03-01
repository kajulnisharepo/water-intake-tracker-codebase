using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterIntakeTracker.DataLayer;
using WaterIntakeTracker.Datalayer.Models;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Services.Interface;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WaterIntakeTracker.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<RegistrationResponseModel>> RegisterUserAsync(UserModel userModel)
        {
            try
            {
                // Check if username or email already exists
                if (await _context.Users.AnyAsync(u => u.Username == userModel.Username || u.Email == userModel.Email))
                {
                    return new ApiResponse<RegistrationResponseModel>
                    {
                        Code = "400",
                        Message = "Username or email already exists",
                        ResponseType = ApiResponseType.Failure
                    };
                }

                // Hash the password
                string hashedPassword = HashPassword(userModel.Password);

                var user = new User
                {
                    Name = userModel.Name,
                    Username = userModel.Username,
                    Email = userModel.Email,
                    Password = hashedPassword,
                    Age = userModel.Age,
                    Weight = userModel.Weight,
                    Height = userModel.Height,
                    BMI = CalculateBMI(userModel.Weight, userModel.Height),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var registrationResponse = new RegistrationResponseModel
                {
                    Message = "Registration Successful!",
                    Name = user.Name,
                    Username = user.Username,
                    Email = user.Email,
                    BMI = user.BMI
                };

                return new ApiResponse<RegistrationResponseModel>
                {
                    Code = "200",
                    Message = "User registered successfully",
                    Data = registrationResponse,
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<RegistrationResponseModel>
                {
                    Code = "500",
                    Message = $"An error occurred while registering the user: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        public async Task<ApiResponse<UserModel>> GetUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return new ApiResponse<UserModel>
                    {
                        Code = "404",
                        Message = "User not found",
                        ResponseType = ApiResponseType.NotFound
                    };
                }

                var userModel = new UserModel
                {
                    Name = user.Name,
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age,
                    Weight = user.Weight,
                    Height = user.Height
                };

                return new ApiResponse<UserModel>
                {
                    Code = "200",
                    Message = "User retrieved successfully",
                    Data = userModel,
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserModel>
                {
                    Code = "500",
                    Message = $"An error occurred while retrieving the user: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        public async Task<ApiResponse<double>> GetUserBMIAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return new ApiResponse<double>
                    {
                        Code = "404",
                        Message = "User not found",
                        ResponseType = ApiResponseType.NotFound
                    };
                }

                return new ApiResponse<double>
                {
                    Code = "200",
                    Message = "BMI retrieved successfully",
                    Data = user.BMI,
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<double>
                {
                    Code = "500",
                    Message = $"An error occurred while retrieving the user's BMI: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        private double CalculateBMI(double weightKg, double heightCm)
        {
            double heightM = heightCm / 100;
            return Math.Round(weightKg / (heightM * heightM), 2);
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }
    }
}
