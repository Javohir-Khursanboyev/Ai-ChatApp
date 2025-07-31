namespace Ai_ChatApp.Shared.DTOs.Users;

public sealed class UserUpdateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserDetailUpdateModel Detail { get; set; }
}
