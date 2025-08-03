using Ai_ChatApp.Data.UnitOfWorks;
using Ai_ChatApp.Service.Extensions;
using Ai_ChatApp.Service.Helpers;
using Ai_ChatApp.Service.Validators.Auth;
using Ai_ChatApp.Shared.DTOs.Auth;
using Ai_ChatApp.Shared.DTOs.Users;
using Ai_ChatApp.Shared.Exceptions;
using AutoMapper;

namespace Ai_ChatApp.Service.Services.Auth;

public sealed class AuthService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    LoginModelValidator loginValidator) : IAuthService
{
    public Task<bool> HasPermissionAsync(long userId, string action, string controller)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginResultModel> LoginAsync(LoginModel loginModel)
    {
        await loginValidator.EnsureValidatedAsync(loginModel);

        var existUser = await unitOfWork.Users
            .SelectAsync(expression: u => u.Email.ToLower() == loginModel.Email.ToLower(), includes: ["Role", "UserDetail.Picture"])
           ?? throw new UnauthorizedException("Email or Password incorrect");

        if (!PasswordHasher.Verify(loginModel.Password, existUser.Password))
            throw new UnauthorizedException("Email or Password incorrect)");

        return new LoginResultModel
        {
            User = mapper.Map<UserViewModel>(existUser),
            Token = AuthHelper.GenerateToken(existUser)
        };
    }
}