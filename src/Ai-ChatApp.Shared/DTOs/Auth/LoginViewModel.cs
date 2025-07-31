using Ai_ChatApp.Shared.DTOs.Users;

namespace Ai_ChatApp.Shared.DTOs.Auth;

public sealed class LoginViewModel
{
    public UserViewModel User { get; set; }
    public string Token { get; set; }
}