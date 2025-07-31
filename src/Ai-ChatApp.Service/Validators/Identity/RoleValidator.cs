using Ai_ChatApp.Domain.Entities.Identity;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Identity;

public sealed class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Role name is required.")
            .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters.");
    }
}