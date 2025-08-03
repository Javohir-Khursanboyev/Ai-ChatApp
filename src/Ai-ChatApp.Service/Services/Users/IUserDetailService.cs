using Ai_ChatApp.Data.UnitOfWorks;
using Ai_ChatApp.Shared.DTOs.Users;
using AutoMapper;

namespace Ai_ChatApp.Service.Services.Users;

public interface IUserDetailService
{
    Task<UserDetailViewModel> CreateAsync(UserDetailCreateModel createModel);
}