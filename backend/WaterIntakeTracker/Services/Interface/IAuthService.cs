using System.Threading.Tasks;
using WaterIntakeTracker.Models;

namespace WaterIntakeTracker.Services.Interface
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> LoginAsync(LoginModel loginModel);
    }
}
