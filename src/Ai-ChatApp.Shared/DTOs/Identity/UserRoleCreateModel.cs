using Ai_ChatApp.Shared.DTOs.Users;

namespace Ai_ChatApp.Shared.DTOs.Identity;

public sealed class UserRoleCreateModel
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}

public sealed class UserRoleUpdateModel
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}

public sealed class UserRoleViewModel
{
    public long Id { get; set; }
    public UserViewModel User { get; set; }
    public RoleViewModel Role { get; set; }
}