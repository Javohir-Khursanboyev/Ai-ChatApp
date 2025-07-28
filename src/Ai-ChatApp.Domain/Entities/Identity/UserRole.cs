using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Entities.Users;

namespace Ai_ChatApp.Domain.Entities.Identity;

public sealed class UserRole : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }
}