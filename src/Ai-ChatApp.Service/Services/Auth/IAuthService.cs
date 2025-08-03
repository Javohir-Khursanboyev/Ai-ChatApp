using Ai_ChatApp.Shared.DTOs.Auth;

namespace Ai_ChatApp.Service.Services.Auth;

public interface IAuthService
{
    Task<LoginResultModel> LoginAsync(LoginModel loginModel);
    //Task<bool> ChangePasswordAsync(long id, ChangePassword changePassword);
    Task<bool> HasPermissionAsync(long userId, string action, string controller);
    //Task<bool> SendVerificationCodeAsync(ResetPasswordRequest model);
    //Task<bool> VerifyCodeAsync(VerifyResetCode model);
    //Task<bool> ResetPasswordAsync(ResetPasswordModel model);
}