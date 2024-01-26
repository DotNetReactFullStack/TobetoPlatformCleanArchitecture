using FluentValidation;

namespace Application.Features.Images.Commands.Create;

public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
{
    public CreateImageCommandValidator()
    {
        RuleFor(c => c.ImageExtensionId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}