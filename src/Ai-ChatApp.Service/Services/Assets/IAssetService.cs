using Ai_ChatApp.Shared.DTOs.Assets;

namespace Ai_ChatApp.Service.Services.Assets;

public interface IAssetService
{
    Task<AssetViewModel> UploadAsync(AssetCreateModel model);
    Task<bool> DeleteAsync(long id);
    Task<AssetViewModel> GetByIdAsync(long id);
}