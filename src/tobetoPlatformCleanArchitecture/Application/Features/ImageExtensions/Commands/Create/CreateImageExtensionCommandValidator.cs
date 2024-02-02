using FluentValidation;

namespace Application.Features.ImageExtensions.Commands.Create;

public class CreateImageExtensionCommandValidator : AbstractValidator<CreateImageExtensionCommand>
{
    public CreateImageExtensionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
    }
}