using Ai_ChatApp.Shared.DTOs.Chats;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Chats;

public sealed class ChatDetailCreateModelValidator : AbstractValidator<ChatDetailCreateModel>
{
    public ChatDetailCreateModelValidator()
    {
        RuleFor(x => x.Text)
           .NotEmpty().WithMessage("Message text must not be empty.")
           .MaximumLength(1000).WithMessage("Message text must not exceed 1000 characters.");

        RuleFor(x => x.SenderType)
            .IsInEnum().WithMessage("Invalid sender type.");
    }
}
