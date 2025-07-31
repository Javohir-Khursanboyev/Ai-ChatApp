using System.Linq;
using Ai_ChatApp.Shared.DTOs.Chats;
using FluentValidation;

namespace Ai_ChatApp.Service.Validators.Chats;

public sealed class ChatUpdateModelValidator : AbstractValidator<ChatUpdateModel>
{
    public ChatUpdateModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Chat nomi bo'sh bo'lmasligi kerak.")
            .MaximumLength(100).WithMessage("Chat nomi 100 belgidan oshmasligi kerak."); RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Chat name must not be empty.")
            .MaximumLength(100).WithMessage("Chat name must not exceed 100 characters.");
    }
}