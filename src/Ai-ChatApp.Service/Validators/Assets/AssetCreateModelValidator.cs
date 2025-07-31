using Ai_ChatApp.Shared.DTOs.Assets;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Ai_ChatApp.Service.Validators.Assets;

public class AssetCreateModelValidator : AbstractValidator<AssetCreateModel>
{
    private readonly string[] _permittedExtensions = [".jpg", ".jpeg", ".png", ".gif", ".pdf", ".docx", ".xlsx"];

    public AssetCreateModelValidator()
    {
        RuleFor(x => x.File)
             .NotNull().WithMessage("File must not be empty.")
             .Must(BeAValidFileType).WithMessage("Invalid file type.");

        RuleFor(x => x.FileType)
            .IsInEnum().WithMessage("Invalid file type specified.");
    }

    private bool BeAValidFileType(IFormFile file)
    {
        if (file == null)
            return false;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _permittedExtensions.Contains(extension);
    }
}