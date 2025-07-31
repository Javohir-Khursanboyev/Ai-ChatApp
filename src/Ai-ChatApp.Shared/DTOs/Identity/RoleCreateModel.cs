namespace Ai_ChatApp.Shared.DTOs.Identity;

public sealed class RoleCreateModel
{
    public string Name { get; set; }
}
public sealed class RoleUpdateModel
{
    public string Name { get; set; }
}

public sealed class RoleViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}