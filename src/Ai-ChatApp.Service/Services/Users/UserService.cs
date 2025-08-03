using Ai_ChatApp.Data.UnitOfWorks;
using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Domain.Entities.Users;
using Ai_ChatApp.Service.Extensions;
using Ai_ChatApp.Service.Helpers;
using Ai_ChatApp.Service.Services.Assets;
using Ai_ChatApp.Service.Services.UserRoles;
using Ai_ChatApp.Service.Validators.Users;
using Ai_ChatApp.Shared.DTOs.Assets;
using Ai_ChatApp.Shared.DTOs.Auth;
using Ai_ChatApp.Shared.DTOs.Identity;
using Ai_ChatApp.Shared.DTOs.Users;
using Ai_ChatApp.Shared.Exceptions;
using AutoMapper;

namespace Ai_ChatApp.Service.Services.Users;

public sealed class UserService(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IAssetService assetService,
    IUserRoleService userRoleService,
    IUserDetailService userDetailService,
    UserCreateModelValidator createModelValidotor,
    UserUpdateModelValidator updateModelValidator) : IUserService
{
    public async Task<LoginViewModel> CreateAsync(UserCreateModel createModel)
    {
        await unitOfWork.BeginTransactionAsync();
        await createModelValidotor.EnsureValidatedAsync(createModel);

        var existUser = await unitOfWork.Users.SelectAsync(u => u.Email == createModel.Email);
        if (existUser is not null)
            throw new AlreadyExistException($"User already exist this email {createModel.Email}");

        var user = mapper.Map<User>(createModel);
        user.Create();
        user.Password = PasswordHasher.Hash(createModel.Password);
        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        var userRole = new UserRoleCreateModel
        {
            UserId = createdUser.Id,
            RoleId = Role.UserId
        };

        await userRoleService.CreateAsync(userRole);

        var userDeatil = new UserDetailCreateModel
        {
            UserId = createdUser.Id,
            PictureId = Asset.DefaultPictureId
        };
        await userDetailService.CreateAsync(userDeatil);
        await unitOfWork.CommitTransactionAsync();

        return new LoginViewModel
        {
            User = mapper.Map<UserViewModel>(createdUser),
            Token = AuthHelper.GenerateToken(createdUser)
        };
    }
    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel)
    {
        await updateModelValidator.EnsureValidatedAsync(updateModel);

        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id, includes: ["UserDetail.Picture"])
            ?? throw new NotFoundException($"User is not found with this ID {id}");

        mapper.Map(updateModel, existUser);
        existUser.Update();
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id)
           ?? throw new NotFoundException($"User is not found with this ID {id}");

        existUser.Delete();
        existUser.IsDeleted = true;
        return await unitOfWork.SaveAsync();
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(expression: u => u.Id == id, includes: ["UserDetail.Picture"])
          ?? throw new NotFoundException($"User is not found with this ID {id}");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<UserViewModel> UploadPictureAsync(long id, AssetCreateModel picture)
    {
        await unitOfWork.BeginTransactionAsync();

        var existUser = await unitOfWork.Users
            .SelectAsync(user => user.Id == id, includes: ["UserDetail.Picture"])
                ?? throw new NotFoundException($"User is not found with this ID={id}");

        var createdPicture = await assetService.UploadAsync(picture);
        existUser.UserDetail.PictureId = createdPicture.Id;
        existUser.UpdatedAt = DateTime.UtcNow;

        await unitOfWork.SaveAsync();
        await unitOfWork.CommitTransactionAsync();

        return mapper.Map<UserViewModel>(existUser);
    }
}