using Ai_ChatApp.Domain.Enums;

namespace Ai_ChatApp.Shared.DTOs.Chats;

public sealed class ChatDetailCreateModel
{
    public string Text { get; set; }
    public SenderType SenderType { get; set; }
}