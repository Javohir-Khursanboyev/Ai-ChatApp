using Ai_ChatApp.Domain.Commons;
using Ai_ChatApp.Domain.Enums;

namespace Ai_ChatApp.Domain.Entities.Resources;

public sealed class Asset : Auditable
{
    public const string DefaultPictureName = "DefaultImage.png";
    public const string DefaultPicturePath = "/assets/images/DefaultImage.png";
    public const long DefaultPictureId = 1;

    public string Name { get; set; }
    public string Path { get; set; }
    public FileType FileType { get; set; }
}
