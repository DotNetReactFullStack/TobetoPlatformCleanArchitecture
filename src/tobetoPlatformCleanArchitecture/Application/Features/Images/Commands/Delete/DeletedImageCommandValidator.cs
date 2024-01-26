using FluentValidation;

namespace Application.Features.Images.Commands.Delete;

public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand>
{
    public DeleteImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}