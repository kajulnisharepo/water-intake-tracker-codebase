using System.Threading.Tasks;
using WaterIntakeTracker.Models;

namespace WaterIntakeTracker.Services.Interface
{
    public interface IUserService
    {
        Task<ApiResponse<RegistrationResponseModel>> RegisterUserAsync(UserModel userModel);
        Task<ApiResponse<UserModel>> GetUserAsync(int id);
        Task<ApiResponse<double>> GetUserBMIAsync(int id);
    }
}
