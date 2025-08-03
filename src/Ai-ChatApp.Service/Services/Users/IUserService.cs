using Ai_ChatApp.Shared.DTOs.Assets;
using Ai_ChatApp.Shared.DTOs.Auth;
using Ai_ChatApp.Shared.DTOs.Users;

namespace Ai_ChatApp.Service.Services.Users;

public interface IUserService
{
    Task<LoginResultModel> CreateAsync(UserCreateModel createModel);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel);
    Task<bool> DeleteAsync(long id);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<UserViewModel> UploadPictureAsync(long id, AssetCreateModel picture);
}