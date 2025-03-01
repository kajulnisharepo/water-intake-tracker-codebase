using System.Threading.Tasks;
using WaterIntakeTracker.Models;

namespace WaterIntakeTracker.Services.Interface
{
    public interface IUserService
    {
        Task<ApiResponse> RegisterUserAsync(UserModel userModel);
        Task<ApiResponse> GetUserAsync(int id);
        Task<ApiResponse> GetUserBMIAsync(int id);
    }
}
