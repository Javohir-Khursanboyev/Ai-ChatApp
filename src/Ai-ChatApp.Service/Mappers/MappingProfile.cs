using Ai_ChatApp.Domain.Entities.Chats;
using Ai_ChatApp.Domain.Entities.Identity;
using Ai_ChatApp.Domain.Entities.Resources;
using Ai_ChatApp.Domain.Entities.Users;
using Ai_ChatApp.Shared.DTOs.Assets;
using Ai_ChatApp.Shared.DTOs.Chats;
using Ai_ChatApp.Shared.DTOs.Identity;
using Ai_ChatApp.Shared.DTOs.Users;
using AutoMapper;

namespace Ai_ChatApp.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Asset, AssetViewModel>().ReverseMap();

        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();

        CreateMap<UserDetailCreateModel, UserDetail>().ReverseMap();
        CreateMap<UserDetailUpdateModel, UserDetail>().ReverseMap();
        CreateMap<UserDetail, UserDetailViewModel>().ReverseMap();

        CreateMap<ChatCreateModel, Chat>().ReverseMap();
        CreateMap<ChatUpdateModel, Chat>().ReverseMap();
        CreateMap<Chat, ChatViewModel>().ReverseMap();

        CreateMap<ChatDetailCreateModel, ChatDetail>().ReverseMap();
        CreateMap<ChatDetail, ChatDetailViewModel>().ReverseMap();

        CreateMap<RoleCreateModel, Role>().ReverseMap();
        CreateMap<RoleUpdateModel, Role>().ReverseMap();
        CreateMap<Role, RoleViewModel>().ReverseMap();

        CreateMap<PermissionCreateModel, Permission>().ReverseMap();
        CreateMap<PermissionUpdateModel, Permission>().ReverseMap();
        CreateMap<Permission, PermissionViewModel>().ReverseMap();

        CreateMap<RolePermissionCreateModel, RolePermission>().ReverseMap();
        CreateMap<RolePermissionUpdateModel, RolePermission>().ReverseMap();
        CreateMap<RolePermission, RolePermissionViewModel>().ReverseMap();

        CreateMap<UserRoleCreateModel, UserRole>().ReverseMap();
        CreateMap<UserRoleUpdateModel, UserRole>().ReverseMap();
        CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
    }
}
