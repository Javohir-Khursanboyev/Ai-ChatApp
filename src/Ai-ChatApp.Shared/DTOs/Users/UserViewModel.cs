using Ai_ChatApp.Shared.DTOs.Chats;

namespace Ai_ChatApp.Shared.DTOs.Users;

public sealed class UserViewModel
{
    public long Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public UserDetailViewModel Detail { get; set; }
    public IEnumerable<ChatViewModel> Chats { get; set; }
}
