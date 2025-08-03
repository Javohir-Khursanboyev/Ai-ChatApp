using Ai_ChatApp.Data.UnitOfWorks;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Service.Extensions;
using Ai_ChatApp.Service.Helpers;
using Ai_ChatApp.Service.Validators.Assets;
using Ai_ChatApp.Shared.DTOs.Assets;
using Ai_ChatApp.Shared.Exceptions;
using AutoMapper;

namespace Ai_ChatApp.Service.Services.Assets;

public sealed class AssetService(IMapper mapper, IUnitOfWork unitOfWork, AssetCreateModelValidator createModelValidator) : IAssetService
{
    public async Task<AssetViewModel> UploadAsync(AssetCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);

        var assetData = await FileHelper.CreateFileAsync(model);
        var asset = new Asset()
        {
            Name = assetData.Name,
            Path = assetData.Path,
            FileType = model.FileType
        };

        asset.Create();
        var createdAsset = await unitOfWork.Assets.InsertAsync(asset);
        await unitOfWork.SaveAsync();

        return mapper.Map<AssetViewModel>(asset);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
            ?? throw new NotFoundException("Asset is not found");

        await unitOfWork.Assets.DropAsync(existAsset);
        return await unitOfWork.SaveAsync();
    }

    public async Task<AssetViewModel> GetByIdAsync(long id)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(asset => asset.Id == id)
           ?? throw new NotFoundException("Asset is not found");

        return mapper.Map<AssetViewModel>(existAsset);
    }
}