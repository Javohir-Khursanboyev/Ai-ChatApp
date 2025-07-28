using Ai_ChatApp.Domain.Commons;

namespace Ai_ChatApp.Domain.Entities.Identity;

public sealed class Permission : Auditable 
{
    public string Action { get; set; }
    public string Controller { get; set; }
    public string Description { get; set; } = string.Empty;
}
