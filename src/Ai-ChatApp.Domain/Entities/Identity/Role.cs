using Ai_ChatApp.Domain.Commons;

namespace Ai_ChatApp.Domain.Entities.Identity;

public sealed class Role : Auditable
{
    public string Name { get; set; }
}
