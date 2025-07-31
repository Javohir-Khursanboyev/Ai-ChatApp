using Ai_ChatApp.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Ai_ChatApp.Shared.DTOs.Assets;

public sealed class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}