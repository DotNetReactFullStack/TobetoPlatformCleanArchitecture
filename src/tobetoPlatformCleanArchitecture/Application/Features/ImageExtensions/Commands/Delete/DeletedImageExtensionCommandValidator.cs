using FluentValidation;

namespace Application.Features.ImageExtensions.Commands.Delete;

public class DeleteImageExtensionCommandValidator : AbstractValidator<DeleteImageExtensionCommand>
{
    public DeleteImageExtensionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}