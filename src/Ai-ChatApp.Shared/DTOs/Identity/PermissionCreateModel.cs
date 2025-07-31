namespace Ai_ChatApp.Shared.DTOs.Identity;

public sealed class PermissionCreateModel
{
    public string Action { get; set; }
    public string Controller { get; set; }
    public string Description { get; set; }
}
public sealed class PermissionUpdateModel
{
    public string Action { get; set; }
    public string Controller { get; set; }
    public string Description { get; set; }
}

public sealed class PermissionViewModel
{
    public long Id { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
    public string Description { get; set; }
}