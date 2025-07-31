using Ai_ChatApp.Domain.Entities.Identity;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Identity;

public sealed class PermissionValidator : AbstractValidator<Permission>
{
    public PermissionValidator()
    {
        RuleFor(x => x.Action)
            .NotEmpty().WithMessage("Action is required.")
            .MaximumLength(100).WithMessage("Action cannot exceed 100 characters.");

        RuleFor(x => x.Controller)
            .NotEmpty().WithMessage("Controller is required.")
            .MaximumLength(100).WithMessage("Controller cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.");
    }
}