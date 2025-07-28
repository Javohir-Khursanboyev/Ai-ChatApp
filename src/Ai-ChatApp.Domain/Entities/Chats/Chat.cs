using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Entities.Users;

namespace Ai_ChatApp.Domain.Entities.Chats;

public sealed class Chat : Auditable
{
    public string Name { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    IEnumerable<ChatDetail> ChatDetails { get; set; }
}
