using Ai_ChatApp.Domain.Entities.Identity;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Identity;

public sealed class RolePermissionValidator : AbstractValidator<RolePermission>
{
    public RolePermissionValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("Role ID must be greater than 0.");

        RuleFor(x => x.PermissionId)
            .GreaterThan(0).WithMessage("Permission ID must be greater than 0.");
    }
}