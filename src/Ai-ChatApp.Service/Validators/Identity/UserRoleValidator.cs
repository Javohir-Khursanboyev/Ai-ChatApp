using Ai_ChatApp.Domain.Entities.Identity;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Identity;

public sealed class UserRoleValidator : AbstractValidator<UserRole>
{
    public UserRoleValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("Role ID must be greater than 0.");
    }
}