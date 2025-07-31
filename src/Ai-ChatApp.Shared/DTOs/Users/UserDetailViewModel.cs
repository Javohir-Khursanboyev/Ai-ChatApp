using Ai_ChatApp.Shared.DTOs.Assets;

namespace Ai_ChatApp.Shared.DTOs.Users;

public sealed class UserDetailViewModel
{
    public long Id { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public AssetViewModel Picture { get; set; }
}
