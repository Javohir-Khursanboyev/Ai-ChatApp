namespace Ai_ChatApp.Shared.DTOs.Identity;

public sealed class RolePermissionCreateModel
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
}
public sealed class RolePermissionUpdateModel
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
}

public sealed class RolePermissionViewModel
{
   public long Id { get; set; }
   public RoleViewModel Role { get; set; }
   public PermissionViewModel Permission { get; set; }
}