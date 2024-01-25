using FluentValidation;

namespace Application.Features.Images.Commands.Update;

public class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand>
{
    public UpdateImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ImageExtensionId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
    }
}