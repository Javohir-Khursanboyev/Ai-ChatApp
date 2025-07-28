using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Entities.Chats;

namespace Ai_ChatApp.Domain.Entities.Users;

public sealed class User : Auditable 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserDetail UserDetail { get; set; }
    public IEnumerable<Chat> Chats { get; set; }
}