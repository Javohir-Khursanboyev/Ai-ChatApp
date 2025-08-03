using Ai_ChatApp.Shared.DTOs.Identity;

namespace Ai_ChatApp.Service.Services.UserRoles;

public interface IUserRoleService
{
    Task<RoleViewModel> CreateAsync(UserRoleCreateModel createModel);
}