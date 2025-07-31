using Ai_ChatApp.Shared.DTOs.Users;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Users;

public sealed class UserCreateModelValidator : AbstractValidator<UserCreateModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(user => user.FirstName)
          .NotEmpty().WithMessage("First name is required.")
          .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(user => user.LastName)
       .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"\d").WithMessage("Password must contain at least one digit.");
    }
}