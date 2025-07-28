using Ai_ChatApp.Domain.Commons;

namespace Ai_ChatApp.Domain.Entities.Identity;

public sealed class RolePermission : Auditable
{
    public long RoleId { get; set; }
    public Role Role { get; set; }
    public long PermissionId { get; set; }
    public Permission Permission { get; set; }  
}