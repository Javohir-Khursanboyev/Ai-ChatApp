using Ai_ChatApp.Data.UnitOfWorks;
using Ai_ChatApp.Domain.Entities.Users;
using Ai_ChatApp.Shared.DTOs.Users;
using AutoMapper;

namespace Ai_ChatApp.Service.Services.Users;

public sealed class UserDetailService(IMapper mapper, IUnitOfWork unitOfWork) : IUserDetailService
{
    public async Task<UserDetailViewModel> CreateAsync(UserDetailCreateModel createModel)
    {
        var mappedUserDetail = mapper.Map<UserDetail>(createModel);

        var createdUserDetail = await unitOfWork.UserDetails.InsertAsync(mappedUserDetail);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserDetailViewModel>(createdUserDetail);
    }
}