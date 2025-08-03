using Ai_ChatApp.Shared.DTOs.Auth;
using Ai_ChatApp.Shared.DTOs.Identity;
using Ai_ChatApp.Shared.DTOs.Users;

namespace Ai_ChatApp.Service.Services.Roles;

public interface IRoleService
{
    Task<RoleViewModel> CreateAsync(RoleCreateModel createModel);
}
