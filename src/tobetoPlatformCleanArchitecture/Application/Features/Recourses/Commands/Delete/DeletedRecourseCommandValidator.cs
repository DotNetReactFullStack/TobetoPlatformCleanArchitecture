using FluentValidation;

namespace Application.Features.Recourses.Commands.Delete;

public class DeleteRecourseCommandValidator : AbstractValidator<DeleteRecourseCommand>
{
    public DeleteRecourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}