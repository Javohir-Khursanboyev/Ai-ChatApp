using Ai_ChatApp.Shared.DTOs.Auth;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Auth;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email must not be empty.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password must not be empty.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}