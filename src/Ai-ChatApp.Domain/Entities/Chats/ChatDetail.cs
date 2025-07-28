using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Enums;

namespace Ai_ChatApp.Domain.Entities.Chats;

public sealed class ChatDetail : Auditable
{
    public string Text { get; set; }
    public SenderType SenderType { get; set; }
    public long ChatId { get; set; }
    public Chat Chat { get; set; }
}
