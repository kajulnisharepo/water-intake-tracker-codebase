using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaterIntakeTracker.DataLayer;
using WaterIntakeTracker.Datalayer.Models;
using WaterIntakeTracker.Models;
using WaterIntakeTracker.Services.Interface;

namespace WaterIntakeTracker.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> RegisterUserAsync(UserModel userModel)
        {
            try
            {
                var user = new User
                {
                    Name = userModel.Name,
                    Age = userModel.Age,
                    Weight = userModel.Weight,
                    Height = userModel.Height,
                    BMI = CalculateBMI(userModel.Weight, userModel.Height),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new ApiResponse
                {
                    code = "200",
                    message = "User registered successfully",
                    ApiResponsedata = new
                    {
                        user.Id,
                        user.Name,
                        user.Age,
                        user.Weight,
                        user.Height,
                        user.BMI,
                        user.CreatedAt,
                        user.UpdatedAt
                    },
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    code = "500",
                    message = $"An error occurred while registering the user: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        public async Task<ApiResponse> GetUserAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return new ApiResponse
                    {
                        code = "404",
                        message = "User not found",
                        ResponseType = ApiResponseType.NotFound
                    };
                }

                return new ApiResponse
                {
                    code = "200",
                    message = "User retrieved successfully",
                    ApiResponsedata = user,
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    code = "500",
                    message = $"An error occurred while retrieving the user: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        public async Task<ApiResponse> GetUserBMIAsync(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return new ApiResponse
                    {
                        code = "404",
                        message = "User not found",
                        ResponseType = ApiResponseType.NotFound
                    };
                }

                var bmiCategory = GetBMICategory(user.BMI);

                return new ApiResponse
                {
                    code = "200",
                    message = "BMI retrieved successfully",
                    ApiResponsedata = new { BMI = user.BMI, Category = bmiCategory },
                    ResponseType = ApiResponseType.Success
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    code = "500",
                    message = $"An error occurred while retrieving the user's BMI: {ex.Message}",
                    ResponseType = ApiResponseType.Failure
                };
            }
        }

        private double CalculateBMI(double weightKg, double heightCm)
        {
            double heightM = heightCm / 100;
            return Math.Round(weightKg / (heightM * heightM), 2);
        }

        private string GetBMICategory(double bmi)
        {
            if (bmi < 18.5) return "Underweight";
            if (bmi < 25) return "Normal weight";
            if (bmi < 30) return "Overweight";
            return "Obese";
        }
    }
}
