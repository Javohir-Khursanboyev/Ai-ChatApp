using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Enums;

namespace Ai_ChatApp.Domain.Entities.Resources;

public sealed class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public FileType FileType { get; set; }
}
