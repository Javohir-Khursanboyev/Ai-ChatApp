using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Entities.Resources;

namespace Ai_ChatApp.Domain.Entities.Users;

public sealed class UserDetail : Auditable
{
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long PictureId { get; set; }
    public Asset Picture { get; set; }
}
