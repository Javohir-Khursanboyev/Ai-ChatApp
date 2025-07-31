using Ai_ChatApp.Shared.DTOs.Chats;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Chats;

public sealed class ChatCreateModelValidator : AbstractValidator<ChatCreateModel>
{
    public ChatCreateModelValidator()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Chat name must not be empty.")
           .MaximumLength(100).WithMessage("Chat name must not exceed 100 characters.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be a positive number.");
    }
}