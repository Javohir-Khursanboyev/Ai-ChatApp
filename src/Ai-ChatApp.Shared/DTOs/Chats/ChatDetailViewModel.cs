using Ai_ChatApp.Domain.Enums;

namespace Ai_ChatApp.Shared.DTOs.Chats;

public sealed class ChatDetailViewModel
{
    public long Id { get; set; }
    public string Texted { get; set; }
    public SenderType SenderType { get; set; }
}