using Ai_ChatApp.Shared.DTOs.Users;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Users;

public sealed class UserDetailUpdateModelValidator : AbstractValidator<UserDetailUpdateModel>
{
    public UserDetailUpdateModelValidator()
    {
        RuleFor(detail => detail.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

        RuleFor(detail => detail.DateOfBirth)
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Date of birth cannot be in the future.");
    }
}