using FluentValidation;

namespace Application.Features.ImageExtensions.Commands.Update;

public class UpdateImageExtensionCommandValidator : AbstractValidator<UpdateImageExtensionCommand>
{
    public UpdateImageExtensionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsActive).NotNull();
    }
}