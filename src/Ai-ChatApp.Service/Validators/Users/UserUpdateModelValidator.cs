using Ai_ChatApp.Shared.DTOs.Users;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Users;

public sealed class UserUpdateModelValidator : AbstractValidator<UserUpdateModel>
{
    public UserUpdateModelValidator()
    {
        RuleFor(user => user.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(user => user.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        // Agar Detail bo'sh bo'lishi mumkin bo'lsa, shunchaki validatsiya qoidalari qo'llash
        RuleFor(user => user.Detail)
            .NotNull().WithMessage("User detail is required.")
            .SetValidator(new UserDetailUpdateModelValidator());
    }
}