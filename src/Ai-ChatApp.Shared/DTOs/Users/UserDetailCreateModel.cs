namespace Ai_ChatApp.Shared.DTOs.Users;

public sealed class UserDetailCreateModel
{
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long UserId { get; set; }
    public long PictureId { get; set; }
}
