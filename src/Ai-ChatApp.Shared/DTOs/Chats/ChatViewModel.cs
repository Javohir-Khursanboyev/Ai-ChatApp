namespace Ai_ChatApp.Shared.DTOs.Chats;

public sealed class ChatViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<ChatDetailViewModel> ChatDetails { get; set; }
}