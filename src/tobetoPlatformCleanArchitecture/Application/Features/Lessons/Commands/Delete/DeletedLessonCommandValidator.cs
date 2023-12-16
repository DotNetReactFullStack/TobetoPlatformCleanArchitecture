using FluentValidation;

namespace Application.Features.Lessons.Commands.Delete;

public class DeleteLessonCommandValidator : AbstractValidator<DeleteLessonCommand>
{
    public DeleteLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}